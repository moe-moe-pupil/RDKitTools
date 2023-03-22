// --------------------------------------------------------------------------------------------------------------
// <copyright file="TimerAction.cs" company="RDKitTools Technologies and contributors.">
// 此源代码的使用受 MIT LICENSE 许可证的约束, 可以在以下链接找到该许可证.
// Use of this source code is governed by the MIT license that can be found through the following link.
// https://github.com/moe-moe-pupil/RDKitTools/blob/main/LICENSE
// </copyright>
// --------------------------------------------------------------------------------------------------------------

namespace RDKitTools.Utils
{
    public interface ITimerAction
    {
        public double StartTime { get; set; }

        public double CurrentTime { get; set; }

        public string Name { get; set; }

        public bool Active { get; set; }

        public bool DefaultActive { get; set; }
    }

    /// <summary lang='Zh-CN'>
    /// 基础计时器行为.
    /// </summary>
    public class TimerAction : ITimerAction
    {
        public TimerAction()
        {
        }

        /// <summary lang='Zh-CN'>
        /// 生成时间.
        /// </summary>
        public double StartTime { get; set; }

        public double CurrentTime { get; set; }

        public string Name { get; set; } = string.Empty;

        public bool Active { get; set; }

        public bool DefaultActive { get; set; }

        public void Reset()
        {
            this.CurrentTime = this.StartTime;
            this.Active = this.DefaultActive;
        }

        public void Start()
        {
            this.Active = true;
        }

        public void Stop()
        {
            this.Active = false;
        }

        public void Toggle()
        {
            this.Active = !this.Active;
        }
    }
}
