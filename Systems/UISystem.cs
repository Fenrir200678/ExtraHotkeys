using Game.UI;

namespace ExtraHotkeys
{
    public partial class UISystem : UISystemBase
    {
        protected override void OnCreate()
        {
            base.OnCreate();
            LogUtil.Info($"{nameof(UISystem)}.{nameof(OnCreate)}");

            try
            {

            }
            catch (System.Exception ex)
            {
                LogUtil.Exception(ex);
            }
        }

        protected override void OnUpdate()
        {
            base.OnUpdate();

            try
            {

            }
            catch (System.Exception ex)
            {
                LogUtil.Exception(ex);
            }
        }
    }
}
