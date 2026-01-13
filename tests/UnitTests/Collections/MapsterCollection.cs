using IntegrationTest.Fixtures;

namespace IntegrationTest.Collections;

[CollectionDefinition("MapsterTests", DisableParallelization = true)]
public class MapsterCollection 
    : ICollectionFixture<MapsterFixture>
{
}