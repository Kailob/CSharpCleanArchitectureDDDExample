using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CADDD.Application.Common.Errors;

public class DuplicateEmailException: Exception, IServiceException
{
    public HttpStatusCode StatusCode => HttpStatusCode.BadRequest; // The proper Code would be Invalid

    public string ErrorMessage => "Invalid Email";
}
