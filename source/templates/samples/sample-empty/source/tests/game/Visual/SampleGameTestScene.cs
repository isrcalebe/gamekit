namespace SampleGame.Game.Tests.Visual;

public abstract partial class SampleGameTestScene : TestScene
{
    protected override ITestSceneTestRunner CreateRunner()
        => new SampleGameTestRunner();

    private partial class SampleGameTestRunner : SampleGameGameBase, ITestSceneTestRunner
    {
        private TestSceneTestRunner.TestRunner? runner;

        protected override void LoadAsyncComplete()
        {
            base.LoadAsyncComplete();

            Add(runner = new TestSceneTestRunner.TestRunner());
        }

        public void RunTestBlocking(TestScene test)
            => runner?.RunTestBlocking(test);
    }
}
