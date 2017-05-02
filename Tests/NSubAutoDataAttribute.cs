namespace Tests
{
    using Ploeh.AutoFixture;
    using Ploeh.AutoFixture.AutoNSubstitute;
    using Ploeh.AutoFixture.Xunit2;

    public class NSubAutoDataAttribute : AutoDataAttribute
    {
        public NSubAutoDataAttribute()
            : base(GetFixture())
        {
        }

        private static IFixture GetFixture()
        {
            var fixture = new Fixture();

            //These 2 lines of code for proper Autofixture generation of parent-child graphs 
            fixture.Behaviors.Remove(new ThrowingRecursionBehavior());
            fixture.Behaviors.Add(new OmitOnRecursionBehavior());

            fixture.Customize(new AutoNSubstituteCustomization());

            return fixture;
        }
    }
}
