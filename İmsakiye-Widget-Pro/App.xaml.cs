using System.Configuration;
using System.Data;
using System.Windows;
using System.Windows.Forms;
using Hardcodet.Wpf.TaskbarNotification;
using Application = System.Windows.Application;

namespace İmsakiye_Widget_Pro
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private TaskbarIcon? notifyIcon;

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            // Sistem tepsisi ikonu oluştur
            notifyIcon = new TaskbarIcon
            {
                Icon = new System.Drawing.Icon(SystemIcons.Application, 40, 40),
                ToolTipText = "İmsakiye Widget Pro"
            };

            // Sağ tık menüsü
            var contextMenu = new System.Windows.Controls.ContextMenu();
            
            var showItem = new System.Windows.Controls.MenuItem { Header = "Widget'ı Göster" };
            showItem.Click += (s, args) => ShowWidget();
            
            var menuItem = new System.Windows.Controls.MenuItem { Header = "Menü" };
            menuItem.Click += (s, args) => ShowMenu();
            
            var settingsItem = new System.Windows.Controls.MenuItem { Header = "Ayarlar" };
            settingsItem.Click += (s, args) => ShowSettings();
            
            var exitItem = new System.Windows.Controls.MenuItem { Header = "Çıkış" };
            exitItem.Click += (s, args) => ExitApp();

            contextMenu.Items.Add(showItem);
            contextMenu.Items.Add(menuItem);
            contextMenu.Items.Add(settingsItem);
            contextMenu.Items.Add(new System.Windows.Controls.Separator());
            contextMenu.Items.Add(exitItem);

            notifyIcon.ContextMenu = contextMenu;
            
            // Çift tıklama ile widget'ı göster
            notifyIcon.TrayLeftMouseDown += (s, args) => ShowWidget();

            // Kontrol panelini arka planda oluştur ama gösterme
            var controlPanel = new ControlPanel();
            controlPanel.Visibility = Visibility.Hidden;
            controlPanel.ShowInTaskbar = false;
            
            // Widget otomatik gösterilecek (ControlPanel_Loaded'da)
        }

        private void ShowWidget()
        {
            foreach (Window window in Current.Windows)
            {
                if (window is WidgetWindow widget)
                {
                    widget.Show();
                    widget.WindowState = WindowState.Normal;
                    widget.Activate();
                    return;
                }
            }
        }

        private void ShowMenu()
        {
            var menuWindow = new MenuWindow();
            menuWindow.ShowDialog();
        }

        private void ShowSettings()
        {
            foreach (Window window in Current.Windows)
            {
                if (window is ControlPanel panel)
                {
                    panel.Show();
                    panel.WindowState = WindowState.Normal;
                    panel.Activate();
                    return;
                }
            }
        }

        private void ExitApp()
        {
            notifyIcon?.Dispose();
            Current.Shutdown();
        }

        protected override void OnExit(ExitEventArgs e)
        {
            notifyIcon?.Dispose();
            base.OnExit(e);
        }
    }
}
