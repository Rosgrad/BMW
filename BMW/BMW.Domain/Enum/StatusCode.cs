using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMW.Domain.Enum
{
    public enum StatusCode
    {
        UserNotFound = 0,
        UserAlreadyExists = 1,
        MedicinesNotFound = 10,
        OK = 200,
        CarNotFound = 10,
        InternalServerError = 500
    }
}
