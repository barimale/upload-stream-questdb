﻿namespace UploadStreamToQuestDB.API.Model {
    public class PaginationRequest {
        public PaginationRequest() {
            // intentionally left blank
        }

        public PaginationRequest(
            int pageIndex,
            int pageSize,
            string startDate,
            string endDate) {
            PageIndex = pageIndex;
            PageSize = pageSize;
            StartDate = startDate;
            EndDate = endDate;
        }

        public int PageIndex { get; set; } = 0;
        public int PageSize { get; set; } = 10;
        public string StartDate { get; set; }
        public string EndDate { get; set; }
    }
}
