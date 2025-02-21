﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Core.CrossCuttingConcerns.Exceptions.HttpProblemDetails;

public class InternalServerErrorProblemDetails : ProblemDetails
{
    public InternalServerErrorProblemDetails(string message)
    {
        Title = "Internal Server Error";
        Detail = message;
        Status = StatusCodes.Status500InternalServerError;
        Type = "https://example.com/problems/business";

    }
}