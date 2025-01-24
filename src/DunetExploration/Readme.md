# Dunet Evaluation
Cool library but it's got some work to go before it beats out rolling your own or any of the others.
With C# Native DUs in the future - I'd like to be able to cleanly switch from my custom ones to those.

Things I think it should handle
- Arity Support - Would allow generation of Union types that have the same name but are denoted by the number of generic args (Result`T1, Result`T2, etc.)
- Variants with Generic Parameters aren't supported. 
- Variants aren't shareable