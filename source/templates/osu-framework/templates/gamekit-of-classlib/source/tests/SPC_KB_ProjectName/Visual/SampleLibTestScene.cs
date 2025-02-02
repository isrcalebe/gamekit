namespace SampleLib.Tests.Visual;

public abstract partial class SampleLibTestScene : TestScene
{
    protected override ITestSceneTestRunner CreateRunner()
        => new SampleLibTestRunner();

    private partial class SampleLibTestRunner : SampleLibTestGame, ITestSceneTestRunner
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
