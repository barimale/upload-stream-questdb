﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using UploadStreamToQuestDB.Application.Handlers.Abstraction;
using UploadStreamToQuestDB.Infrastructure.Model;
using static File.Api.Controllers.UploadController;

namespace UploadStreamToQuestDB.Application.Handlers {
    public class ExtensionHandler : AbstractHandler {
        private readonly Controller controller;
        private readonly IConfiguration configuration;
        public ExtensionHandler(
            Controller controller,
            IConfiguration configuration) {
            this.controller = controller;
            this.configuration = configuration;
        }
        public override object Handle(FileModels files) {
            try {
                // check extensions of streamed files
                foreach (var file in files) {
                    string extension = Path.GetExtension(file.file.FileName);
                    if (!extension.EndsWith(configuration["AllowedExtension"]))
                        throw new Exception();
                }

                files.State = FileModelState.EXTENSION_OK;
            } catch (Exception) {

                throw;
            }

            return base.Handle(files);
        }
    }
}