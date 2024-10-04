namespace Model.Generic
{
    // Class Result Data Model
    public class ResultDM
    {
        // Result Information
        public Information Information { get; set; } = new Information();

        // Result Object Request
        public object Req { get; set; } = "";

        // Result Object Response
        public object? Res { get; set; }
    }

    // Class Information 
    public class Information
    {
        // Response Status
        public string Status { get; set; } = "Not Defined";

        // Response Message
        public string Message { get; set; } = "Not Defined";

        /* 
         * Save = 0
         * Get = 1
         * Remove = 2
         * Custom = 3
         */
        public Information ResultInformation(string message, int eventId, int statusCode)
        {
            Information information = new Information();

            switch (eventId)
            {
                case 0:
                    information = Save(message, statusCode, information);
                    break;
                case 1:
                    information = Get(message, statusCode, information);
                    break;
                case 2:
                    information = Remove(message, statusCode, information);
                    break;
                case 3:
                    information = Custom(message, statusCode, information);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(eventId), "Invalid event code");

            }

            return information;
        }

        /* 
         * Success = 0
         * Error = 1
         * Warning = 2
         * Info = 3
         */
        private Information Custom(string message, int statusCode, Information information)
        {
            information.Message = $"{message}";
            switch (statusCode)
            {
                case 0:
                    information.Status = $"success";
                    break;
                case 1:
                    information.Status = $"error";
                    break;
                case 2:
                    information.Status = $"warning";
                    break;
                case 3:
                    information.Status = $"info";
                    break;
            }
            return information;
        }

        /* 
         * success = 0
         * Error = 1
         */
        private Information Remove(string message, int statusCode, Information information)
        {
            switch (statusCode)
            {
                case 0:
                    information.Message = $"{message} removido com sucesso!";
                    information.Status = $"success";
                    break;
                case 1:
                    information.Message = $"Erro ao remover {message}!";
                    information.Status = $"error";
                    break;
            }
            return information;
        }

        /* 
         * success = 0
         * Error = 1
         */
        private Information Save(string message, int statusCode, Information information)
        {
            switch (statusCode)
            {
                case 0:
                    information.Message = $"{message} salvo com sucesso!";
                    information.Status = $"success";
                    break;
                case 1:
                    information.Message = $"Erro ao salvar {message}!";
                    information.Status = $"error";
                    break;
            }
            return information;
        }

        /* 
         * success = 0
         * Error = 1
         */
        private Information Get(string message, int statusCode, Information information)
        {
            switch (statusCode)
            {
                case 0:
                    information.Message = $"{message} coletado com sucesso!";
                    information.Status = $"success";
                    break;
                case 1:
                    information.Message = $"Falha para pegar o {message}!";
                    information.Status = $"error";
                    break;
            }

            return information;
        }
    }

    public class EnumResultDM
    {
        public enum EventCode : int
        {
            CodeSave = 0,
            CodeGet = 1,
            CodeRemove = 2,
            CodeCustom = 3
        }
        /* 
         * Success = 0
         * Error = 1
         * Warning = 2
         * Info = 3
         */
        public enum StatusCode
        {
            StatusSuccess,
            StatusError,
            StatusWarning,
            StatusInfo
        }
    }
}