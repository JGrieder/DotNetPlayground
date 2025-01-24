using System.ComponentModel.DataAnnotations;
using Dunet;
using Microsoft.Extensions.Logging;

namespace DunetExploration.Dunet_Examples;

/*
 * As separate "Unions" - Dunet will not allow you to generate unions of the same name
 * even if they have different arity (number of holes or generic arguments)
 *
 * Possible Workarounds
 * - Override File Namespace and Suppress CheckNamespace Warning - Confirmed
 * - Nesting Classes (Should work the same way as Override File Namespace)
 * - Unique Names (Result, Result<TError> => ErrorResult)
 * - Inheritance chain - Least Specific to Most? - Constructor in Generated Type is Private, needs to be protected
 */

/* Notes:
 * - Doesn't generate implicit operators.
 * 
 */
[Union]
public partial record Result<TSuccess, TError>
{
    partial record Success(TSuccess Value);
    partial record Error(EventId EventId, TError ErrorState);
}

//This doesn't work - source generator makes invalid code
// [Union]
// public partial record ResultAlt
// {
//     partial record Success<TValue>(TValue Value);
//
//     partial record Error<TErrorState>(EventId EventId, TErrorState ErrorState);
// }

[Union]
public partial record ValidatedResult<T, TError>
{
    //Allows you to return Nothing if Successful
    partial record Success(Option<T> Value);
    //This is a built-in type - can roll your own - might be beneficial to communicate an EventId if a Domain Validation is triggered
    partial record Invalid(IEnumerable<ValidationResult> Results);
    
    partial record Error(EventId EventId, Option<TError> Value);
    
}



