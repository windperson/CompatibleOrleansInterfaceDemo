﻿namespace OrleansHelloWorld.GrainInterfaces;

public interface IHello: IGrainWithIntegerKey
{
    ValueTask<string> SayHello(string greeting);    
}