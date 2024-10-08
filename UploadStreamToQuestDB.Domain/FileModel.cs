﻿using Microsoft.AspNetCore.Http;
using UploadStreamToQuestDB.Infrastructure.Model;

namespace File.Api.Controllers {
        public class FileModel {
            public IFormFile file;
            public string FilePath;
            public List<FileModelState> State = new List<FileModelState>();
            public string GetState() {
                return string.Join(",", this.State.Select(p => p.ToString()));
            }
        }
}
