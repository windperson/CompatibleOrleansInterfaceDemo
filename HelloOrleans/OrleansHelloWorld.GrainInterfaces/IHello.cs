namespace OrleansHelloWorld.GrainInterfaces;

using Orleans;

public interface IHello : IGrainWithIntegerKey
{
    ValueTask<string> SayHello(string greeting);
}