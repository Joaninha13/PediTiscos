﻿namespace RCLProdutos.Services.Interfaces;

public interface ISliderUtilsServices
{
    int Index { get; set; }
    int CountSlide { get; set; }
    float WidthSlide2 { get; set; }
    List<string> MarginLeftSlide { get; set; }

    public event Action OnChange;
}
