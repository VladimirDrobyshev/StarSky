using System.Drawing;

namespace Core;

/// <summary>
/// Структура описывающая одну звезду
/// </summary>
public struct StarInfo
{
    /// <summary>
    /// Прямое восхождение
    /// </summary>
    public double RightAscension { get; set; }
    /// <summary>
    /// Склонение
    /// </summary>
    public double Declination { get; set; }
    /// <summary>
    /// Цвет звезды
    /// </summary>
    public Color Color { get; set; }
    /// <summary>
    /// Звездная величина
    /// </summary>
    public float Magnitude { get; set; }
}