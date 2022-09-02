using GameEngine.Interfaces;

namespace GameEngine.Enviroment
{
    public static class ThreadSafeInvoker
    {
        delegate void RunCallBack(IUISchedule ui, bool byStep);
        delegate void RestartCallBack(IUISchedule ui);

        public static void Run(IUISchedule ui, bool byStep)
        {

            Form form = (Form)ui;

            if (form.InvokeRequired)
            {
                RunCallBack d = new(Run);

                try
                {
                    form.Invoke(d, new object[] { form, byStep });
                }
                catch (Exception ex)
                {
                    if (!ex.Message.StartsWith("Cannot access a disposed object."))
                        throw;
                }
            }
            else
            {
                ((IUISchedule)form).Run(byStep);
            }
        }

        public static void Restart(IUISchedule ui)
        {

            Form form = (Form)ui;

            if (form.InvokeRequired)
            {
                RestartCallBack d = new(Restart);

                try
                {
                    form.Invoke(d, new object[] { form });
                }
                catch (Exception ex)
                {
                    if (!ex.Message.StartsWith("Cannot access a disposed object."))
                        throw;
                }
            }
            else
            {
                ((IUISchedule)form).Restart();
            }
        }
    }
}