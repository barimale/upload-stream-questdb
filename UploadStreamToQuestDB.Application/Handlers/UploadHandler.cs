﻿using Microsoft.AspNetCore.Mvc;
using UploadStream;
using UploadStreamToQuestDB.Application.Handlers.Abstraction;
using UploadStreamToQuestDB.Domain;

namespace UploadStreamToQuestDB.Application.Handlers {
    public class UploadHandler : AbstractHandler {
        private readonly Controller controller;

        public UploadHandler(Controller controller) {
            this.controller = controller;
        }
        public async Task<object> Handle(FileModelsInput files) {
            await controller.Request.StreamFilesModel(async x => {
                using (var stream = x.OpenReadStream()) {
                    if (!Directory.Exists(files.FilePath)) {
                        Directory.CreateDirectory(files.FilePath);
                    }
                    using (var fileStream = new FileStream(
                        Path.Join(files.FilePath, x.FileName),
                        FileMode.Create)) {
                        await stream.CopyToAsync(fileStream);
                    }
                    var entry = new FileModel() {
                        file = x,
                        FilePath = Path.Join(files.FilePath, x.FileName),
                    };
                    entry.State.Add(FileModelState.UPLOADED);
                    files.Add(entry);
                }
            });

            return base.Handle(files);
        }
    }
}
