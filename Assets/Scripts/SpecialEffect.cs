namespace Asteroids
{
    public sealed class SpecialEffect: ObjectWithLifeTime<SpecialEffect>
    {
        public override event DisableAction<SpecialEffect> disableEvent;

        public override void DisableEventInvoke()
        {
            disableEvent?.Invoke(this);
        }
    }
}