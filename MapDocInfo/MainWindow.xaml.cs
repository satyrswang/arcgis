using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Geometry;

namespace MapDocInfo
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        AxMapControl m_map = new AxMapControl();
        AxTOCControl m_toc = new AxTOCControl();
        AxToolbarControl m_toolbar = new AxToolbarControl();
        public MainWindow()
        {
            InitializeComponent();
            this.mapControlHost.Child = m_map;
            this.tocHost.Child = m_toc;
            this.toolbarHost.Child = m_toolbar;
        }

        private void btnInfo_Click(object sender, RoutedEventArgs e)
        {
            if (this.m_map.Map is IActiveView)
            {
                //Cast Imap to IActiveView
                IActiveView actView = (IActiveView)this.m_map.ActiveView;
                //System.Diagnostics.Debug.WriteLine("Test map is "+mapDoc.MapCount);
                // Console.Out.WriteLine("The sum of maps is " + mapDoc.MapCount);
                Console.Out.WriteLine("The first map is " + this.m_map.Map.Name);
                Console.Out.WriteLine("The actView map is " + actView.FocusMap.Name);
                //axMapControl1.LoadMxFile(mapDoc.DocumentFilename);
                //method 3, Set a map directly
                IEnvelope env = actView.Extent;
                MessageBox.Show("Min(" + env.XMin.ToString() + "," + env.XMin + "),Max(" + env.XMax.ToString() + "," + env.YMax + ")");
            }

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            IMapDocument mapDoc = new MapDocument();
            mapDoc.Open("C:\\IPAN\\Exercise02\\SouthAmerica.mxd");
            /// IMap inMap = mapDoc.get_Map(0);//mapDoc.get_Map(0);
            m_map.Map = mapDoc.get_Map(0);
            m_toc.SetBuddyControl(m_map);
            m_toolbar.SetBuddyControl(m_map);
            m_toolbar.AddItem("esriControls.ControlsMapNavigationToolbar");

        }
    }
}
