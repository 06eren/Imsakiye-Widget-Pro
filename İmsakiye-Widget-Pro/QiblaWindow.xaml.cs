using System;
using System.Windows;

namespace İmsakiye_Widget_Pro
{
    public partial class QiblaWindow : Window
    {
        public QiblaWindow()
        {
            InitializeComponent();
            CalculateQiblaDirection();
        }

        private void CalculateQiblaDirection()
        {
            // Kabe koordinatları
            double kaabaLat = 21.4225;
            double kaabaLon = 39.8262;
            
            // Ankara koordinatları (örnek)
            double userLat = 39.9334;
            double userLon = 32.8597;
            
            // Kıble açısını hesapla
            double angle = CalculateBearing(userLat, userLon, kaabaLat, kaabaLon);
            
            QiblaRotation.Angle = angle;
            QiblaAngleText.Text = $"Kıble Açısı: {angle:F1}°";
            LocationText.Text = $"Konum: Ankara ({userLat:F4}, {userLon:F4})";
        }

        private double CalculateBearing(double lat1, double lon1, double lat2, double lon2)
        {
            double dLon = ToRadians(lon2 - lon1);
            double y = Math.Sin(dLon) * Math.Cos(ToRadians(lat2));
            double x = Math.Cos(ToRadians(lat1)) * Math.Sin(ToRadians(lat2)) -
                      Math.Sin(ToRadians(lat1)) * Math.Cos(ToRadians(lat2)) * Math.Cos(dLon);
            double bearing = ToDegrees(Math.Atan2(y, x));
            return (bearing + 360) % 360;
        }

        private double ToRadians(double degrees) => degrees * Math.PI / 180;
        private double ToDegrees(double radians) => radians * 180 / Math.PI;

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
