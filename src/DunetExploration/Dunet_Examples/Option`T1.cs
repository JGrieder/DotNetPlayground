using Dunet;

namespace DunetExploration.Dunet_Examples;

[Union]
public partial record Option<T>
{
    partial record Some(T Value);
    partial record None();
};

