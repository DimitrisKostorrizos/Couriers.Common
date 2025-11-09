# Description

This project contains the common types, used across the implementations for Courier API clients. 
The design used for the client methods, is a Result Type approach. All the client methods, return an IHttpRequestResult, as the return type, 
instead of throwing exceptions. The result instance contains the possible result of the method, along with the HTTP request payload 
text and response text. In case of any error, the property ErrorMessage can be used to identify the possible error.

### Basic Usage

```cs
var result = Method(....)

if(result.IsSuccessful)
	HandleTheUnsuccessfulCase();
		
HandleTheSuccessfulCase();
```