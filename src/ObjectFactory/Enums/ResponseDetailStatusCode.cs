using System.ComponentModel;

namespace SEFI.Enums
{
    public enum ResponseDetailStatusCode : int
    {
        [Description("")]
        [Category("Warning")]
        Warning = 100,

        [Description("Bad Request")]
        [Category("Error")]
        BadRequest = 400,
        
        [Description("Unauthorized")]
        [Category("Error")]
        Unauthorized = 401,

        [Description("Forbidden")]
        [Category("Error")]
        Forbidden = 403,

        [Description("Not Found")]
        [Category("Error")]
        NotFound = 404,

        [Description("Not Allowed")]
        [Category("Error")]
        NotAllowed = 405,

        [Description("Unprocessable Entity")]
        [Category("Error")]
        UnprocessableEntity = 422,

        [Description("Conflict")]
        [Category("Error")]
        Conflict = 409
    }
}
