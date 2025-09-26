// <copyright file="Monkey.cs" company="YourCompany">
// Copyright (c) YourCompany. All rights reserved.
// </copyright>

namespace MyMonkeyApp;

/// <summary>
/// 원숭이 정보를 나타내는 모델 클래스입니다.
/// </summary>
public class Monkey
{
    /// <summary>
    /// 원숭이 이름
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// 서식지 또는 위치
    /// </summary>
    public string Location { get; set; } = string.Empty;

    /// <summary>
    /// 원숭이 개체수
    /// </summary>
    public int Population { get; set; }

    /// <summary>
    /// 원숭이에 대한 설명
    /// </summary>
    public string Details { get; set; } = string.Empty;

    /// <summary>
    /// 원숭이 이미지 URL
    /// </summary>
    public string Image { get; set; } = string.Empty;

    /// <summary>
    /// 위도
    /// </summary>
    public double Latitude { get; set; }

    /// <summary>
    /// 경도
    /// </summary>
    public double Longitude { get; set; }
}
