using System.ComponentModel;

namespace SEFI.Enums
{
    public enum ResponseStatusCode : int
    {
        [Description("Warning")]
        Warning = 100,

        [Description("Failed")]
        Failed = 400,

        [Description("Not Authorized")]
        NotAuthorized = 401,

        [Description("No Permission")]
        NoPermission = 403,

        [Description("Not Found")]
        NotFound = 404,

        [Description("Not Allowed")]
        NotAllowed = 405,

        [Description("Conflict")]
        Conflict = 409,

        [Description("Unprocessible")]
        Unprocessible = 422,

        [Description("Success")]
        Success = 204,

        [Description("Success with message(s)")]
        SuccessWithMessage = 200,
    }
}
