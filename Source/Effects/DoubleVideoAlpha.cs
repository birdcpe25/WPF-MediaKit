using System;
using System.Reflection;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Effects;

namespace WPFMediaKit.Effects
{
    public class DoubleVideoAlphaEffect : ShaderEffect
    {

        private static string m_assemblyShortName;

        public static DependencyProperty InputProperty = RegisterPixelShaderSamplerProperty("Input", typeof(DoubleVideoAlphaEffect), 0);

        public DoubleVideoAlphaEffect()
        {
            var u = new Uri(@"pack://application:,,,/" + AssemblyShortName + ";component/Effects/DoubleVideoAlpha.ps");
            PixelShader = new PixelShader { UriSource = u };
            UpdateShaderValue(InputProperty);
        }
        private static string AssemblyShortName
        {
            get
            {
                if (m_assemblyShortName == null)
                {
                    Assembly a = typeof(DoubleVideoAlphaEffect).Assembly;
                    m_assemblyShortName = a.ToString().Split(',')[0];
                }

                return m_assemblyShortName;
            }
        }
        public Brush Input
        {
            get
            {
                return ((Brush)(GetValue(InputProperty)));
            }
            set
            {
                SetValue(InputProperty, value);
            }
        }
    }
}
