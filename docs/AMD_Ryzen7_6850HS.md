﻿## 目的

了解 CPU 在日常待机情况下的数据，方便 RyzenTuner 配置合适的参数。

## 基本信息

1. 测试 CPU：AMD Ryzen™ 7 PRO 6850HS
    * TDP：35W
    * 基础频率：3.2GHz
    * 最大加速时钟频率：4.7GHz
    * 最高温度：95 ℃
2.
测试代码：[DebugUtils.cs#L12-L23](https://github.com/zqhong/RyzenTuner/blob/1af00263b1222fdaa9e6a2e1016c2954d65e0d5a/Utils/DebugUtils.cs#L12-L23)
3. 室温 26 ℃

## 待机

### 测试内容

1. 后台运行日常软件，比如微信、Chrome、终端
2. 前台运行 IDE

### 关闭睿频

```text
功率：限制1瓦、实际4.28瓦，CPU：19.12%、51.88℃、399.27MHz，GPU：2.87%
功率：限制2瓦、实际4.36瓦，CPU：29.95%、50.88℃、399.27MHz，GPU：5.80%
功率：限制3瓦、实际4.07瓦，CPU：16.84%、50.13℃、399.27MHz，GPU：2.75%
功率：限制4瓦、实际4.06瓦，CPU：6.63%、49.63℃、1343.98MHz，GPU：2.25%
功率：限制5瓦、实际4.57瓦，CPU：3.50%、49.25℃、1397.45MHz，GPU：2.35%
功率：限制6瓦、实际5.63瓦，CPU：3.58%、49.13℃、1397.45MHz，GPU：2.61%
功率：限制7瓦、实际6.92瓦，CPU：2.41%、49.25℃、2720.04MHz，GPU：2.13%
功率：限制8瓦、实际7.62瓦，CPU：0.71%、49.75℃、3169.22MHz，GPU：1.84%
功率：限制9瓦、实际7.66瓦，CPU：0.72%、49.88℃、3169.22MHz，GPU：1.72%
功率：限制10瓦、实际7.64瓦，CPU：0.71%、49.88℃、3169.22MHz，GPU：1.76%
功率：限制11瓦、实际7.68瓦，CPU：1.09%、49.88℃、3169.22MHz，GPU：1.71%
功率：限制12瓦、实际7.66瓦，CPU：0.85%、50.00℃、3169.22MHz，GPU：1.79%
功率：限制13瓦、实际7.61瓦，CPU：0.66%、49.88℃、3169.22MHz，GPU：1.75%
功率：限制14瓦、实际7.64瓦，CPU：0.66%、50.00℃、3169.22MHz，GPU：1.90%
功率：限制15瓦、实际7.72瓦，CPU：0.95%、50.00℃、3169.22MHz，GPU：1.78%
功率：限制16瓦、实际7.64瓦，CPU：0.85%、50.00℃、3169.22MHz，GPU：1.67%
功率：限制17瓦、实际7.62瓦，CPU：0.70%、50.00℃、3169.22MHz，GPU：1.77%
功率：限制18瓦、实际7.67瓦，CPU：0.71%、50.13℃、3169.22MHz，GPU：1.83%
功率：限制19瓦、实际7.64瓦，CPU：0.95%、50.13℃、3169.22MHz，GPU：1.75%
功率：限制20瓦、实际7.59瓦，CPU：1.10%、50.00℃、3169.22MHz，GPU：1.76%
功率：限制21瓦、实际7.73瓦，CPU：0.90%、50.00℃、3169.22MHz，GPU：1.68%
功率：限制22瓦、实际7.72瓦，CPU：1.57%、50.00℃、3169.22MHz，GPU：1.99%
功率：限制23瓦、实际7.66瓦，CPU：0.72%、50.00℃、3169.22MHz，GPU：1.75%
功率：限制24瓦、实际7.67瓦，CPU：0.67%、50.00℃、3169.22MHz，GPU：1.73%
功率：限制25瓦、实际7.62瓦，CPU：0.71%、50.13℃、3169.22MHz，GPU：1.74%
功率：限制26瓦、实际7.62瓦，CPU：0.76%、50.13℃、3169.22MHz，GPU：1.75%
功率：限制27瓦、实际7.71瓦，CPU：1.18%、50.13℃、3169.22MHz，GPU：1.81%
功率：限制28瓦、实际7.80瓦，CPU：0.90%、50.38℃、3169.22MHz，GPU：1.93%
功率：限制29瓦、实际7.73瓦，CPU：0.71%、50.25℃、3169.22MHz，GPU：1.80%
功率：限制30瓦、实际7.60瓦，CPU：0.57%、50.25℃、3169.22MHz，GPU：1.78%
```

### 开启睿频

```text
功率：限制1瓦、实际4.26瓦，CPU：19.17%、49.50℃、399.27MHz，GPU：3.33%
功率：限制2瓦、实际3.98瓦，CPU：17.43%、48.88℃、399.27MHz，GPU：2.76%
功率：限制3瓦、实际3.99瓦，CPU：16.78%、48.38℃、399.27MHz，GPU：2.77%
功率：限制4瓦、实际4.04瓦，CPU：7.57%、48.13℃、1397.45MHz，GPU：2.71%
功率：限制5瓦、实际4.53瓦，CPU：2.75%、48.00℃、1397.45MHz，GPU：2.53%
功率：限制6瓦、实际5.73瓦，CPU：3.34%、48.00℃、1397.45MHz，GPU：2.20%
功率：限制7瓦、实际6.94瓦，CPU：2.15%、48.13℃、1597.09MHz，GPU：2.18%
功率：限制8瓦、实际8.35瓦，CPU：0.95%、49.00℃、2670.13MHz，GPU：1.91%
功率：限制9瓦、实际9.39瓦，CPU：1.00%、49.88℃、3437.48MHz，GPU：2.04%
功率：限制10瓦、实际10.38瓦，CPU：0.72%、50.88℃、3169.22MHz，GPU：1.90%
功率：限制11瓦、实际11.33瓦，CPU：0.47%、51.63℃、3654.79MHz，GPU：1.84%
功率：限制12瓦、实际11.76瓦，CPU：0.95%、52.50℃、3169.22MHz，GPU：1.82%
功率：限制13瓦、实际12.02瓦，CPU：0.75%、53.13℃、3169.22MHz，GPU：1.94%
功率：限制14瓦、实际12.28瓦，CPU：0.95%、53.88℃、3169.22MHz，GPU：1.83%
功率：限制15瓦、实际12.18瓦，CPU：0.71%、54.13℃、3169.22MHz，GPU：2.01%
功率：限制16瓦、实际12.19瓦，CPU：0.66%、54.25℃、3169.22MHz，GPU：1.91%
功率：限制17瓦、实际12.53瓦，CPU：0.66%、54.63℃、3358.45MHz，GPU：2.05%
功率：限制18瓦、实际12.55瓦，CPU：0.80%、54.88℃、3169.22MHz，GPU：1.86%
功率：限制19瓦、实际12.69瓦，CPU：0.90%、55.13℃、3169.22MHz，GPU：1.98%
功率：限制20瓦、实际12.55瓦，CPU：0.56%、55.38℃、3093.31MHz，GPU：1.84%
功率：限制21瓦、实际12.57瓦，CPU：0.67%、55.75℃、3169.22MHz，GPU：1.93%
功率：限制22瓦、实际12.42瓦，CPU：0.76%、55.88℃、3164.02MHz，GPU：1.93%
功率：限制23瓦、实际12.62瓦，CPU：0.95%、56.13℃、3169.22MHz，GPU：1.96%
功率：限制24瓦、实际13.01瓦，CPU：0.66%、56.50℃、4071.74MHz，GPU：1.84%
功率：限制25瓦、实际12.89瓦，CPU：0.62%、56.63℃、3363.65MHz，GPU：1.85%
功率：限制26瓦、实际12.95瓦，CPU：0.43%、56.75℃、3169.22MHz，GPU：1.88%
功率：限制27瓦、实际12.71瓦，CPU：1.04%、56.88℃、3169.22MHz，GPU：2.05%
功率：限制28瓦、实际12.50瓦，CPU：0.95%、56.88℃、3169.22MHz，GPU：1.97%
功率：限制29瓦、实际12.52瓦，CPU：0.62%、57.00℃、3680.78MHz，GPU：1.96%
功率：限制30瓦、实际12.66瓦，CPU：1.23%、57.13℃、3358.46MHz，GPU：1.95%
```

## 轻度使用

### 测试内容

1. 播放哔哩哔哩 1080P
   高码率视频：[https://www.bilibili.com/video/BV11V4y1J7Rm](https://www.bilibili.com/video/BV11V4y1J7Rm)
2. 开启弹幕，智能云屏蔽：3级

### 关闭睿频

```text
功率：限制1瓦、实际4.97瓦，CPU：49.02%、49.63℃、399.27MHz，GPU：7.26%
功率：限制2瓦、实际4.92瓦，CPU：50.70%、48.63℃、399.27MHz，GPU：9.86%
功率：限制3瓦、实际4.91瓦，CPU：58.71%、47.88℃、399.27MHz，GPU：12.65%
功率：限制4瓦、实际4.75瓦，CPU：54.32%、47.38℃、399.27MHz，GPU：10.22%
功率：限制5瓦、实际5.14瓦，CPU：50.99%、47.13℃、476.47MHz，GPU：11.07%
功率：限制6瓦、实际5.66瓦，CPU：13.21%、47.00℃、1397.45MHz，GPU：7.76%
功率：限制7瓦、实际6.64瓦，CPU：4.65%、46.88℃、1430.72MHz，GPU：6.06%
功率：限制8瓦、实际7.94瓦，CPU：6.89%、47.00℃、3169.22MHz，GPU：5.53%
功率：限制9瓦、实际8.42瓦，CPU：2.30%、47.38℃、3169.22MHz，GPU：4.74%
功率：限制10瓦、实际8.60瓦，CPU：2.37%、47.63℃、3119.31MHz，GPU：4.66%
功率：限制11瓦、实际9.25瓦，CPU：4.31%、48.00℃、3169.22MHz，GPU：7.42%
功率：限制12瓦、实际10.04瓦，CPU：5.40%、48.63℃、3169.22MHz，GPU：11.52%
功率：限制13瓦、实际9.65瓦，CPU：4.15%、48.75℃、3169.22MHz，GPU：11.06%
功率：限制14瓦、实际9.44瓦，CPU：3.98%、48.88℃、3169.22MHz，GPU：11.36%
功率：限制15瓦、实际10.17瓦，CPU：4.68%、49.38℃、3169.22MHz，GPU：11.36%
功率：限制16瓦、实际8.82瓦，CPU：2.62%、49.25℃、3169.22MHz，GPU：6.16%
功率：限制17瓦、实际9.90瓦，CPU：3.36%、49.75℃、3169.22MHz，GPU：10.97%
功率：限制18瓦、实际9.82瓦，CPU：4.29%、50.00℃、3169.22MHz，GPU：10.58%
功率：限制19瓦、实际9.24瓦，CPU：2.98%、50.25℃、3169.22MHz，GPU：9.25%
功率：限制20瓦、实际9.15瓦，CPU：3.48%、50.38℃、3169.22MHz，GPU：4.71%
功率：限制21瓦、实际8.70瓦，CPU：2.70%、50.50℃、3169.22MHz，GPU：4.83%
功率：限制22瓦、实际9.03瓦，CPU：2.82%、50.75℃、3169.22MHz，GPU：4.83%
功率：限制23瓦、实际9.09瓦，CPU：4.07%、51.00℃、3169.22MHz，GPU：4.54%
功率：限制24瓦、实际8.93瓦，CPU：3.13%、51.00℃、3169.22MHz，GPU：6.14%
功率：限制25瓦、实际9.98瓦，CPU：4.79%、51.13℃、3169.22MHz，GPU：11.21%
功率：限制26瓦、实际9.66瓦，CPU：4.63%、51.00℃、3169.22MHz，GPU：10.97%
功率：限制27瓦、实际9.15瓦，CPU：3.84%、50.75℃、3169.22MHz，GPU：6.48%
功率：限制28瓦、实际8.57瓦，CPU：3.20%、50.38℃、3169.22MHz，GPU：4.57%
功率：限制29瓦、实际8.76瓦，CPU：3.38%、50.25℃、3169.22MHz，GPU：4.71%
功率：限制30瓦、实际8.50瓦，CPU：2.43%、50.00℃、3169.22MHz，GPU：4.69%
```

### 开启睿频

```text
功率：限制1瓦、实际4.50瓦，CPU：24.81%、49.13℃、399.27MHz，GPU：8.85%
功率：限制2瓦、实际4.37瓦，CPU：27.98%、48.25℃、399.27MHz，GPU：8.38%
功率：限制3瓦、实际4.30瓦，CPU：27.54%、47.75℃、399.27MHz，GPU：8.11%
功率：限制4瓦、实际4.30瓦，CPU：18.23%、47.25℃、456.64MHz，GPU：8.32%
功率：限制5瓦、实际4.81瓦，CPU：10.70%、47.00℃、1397.45MHz，GPU：6.44%
功率：限制6瓦、实际5.52瓦，CPU：7.10%、46.75℃、1397.45MHz，GPU：6.58%
功率：限制7瓦、实际6.72瓦，CPU：4.41%、46.75℃、1756.80MHz，GPU：6.13%
功率：限制8瓦、实际7.89瓦，CPU：3.94%、47.38℃、3234.10MHz，GPU：5.13%
功率：限制9瓦、实际9.32瓦，CPU：4.32%、48.38℃、2036.91MHz，GPU：5.07%
功率：限制10瓦、实际10.30瓦，CPU：3.39%、49.25℃、3690.14MHz，GPU：4.72%
功率：限制11瓦、实际11.37瓦，CPU：2.70%、50.50℃、3169.22MHz，GPU：5.23%
功率：限制12瓦、实际12.39瓦，CPU：2.58%、51.75℃、3040.29MHz，GPU：4.95%
功率：限制13瓦、实际13.34瓦，CPU：2.77%、53.00℃、3169.22MHz，GPU：5.02%
功率：限制14瓦、实际14.30瓦，CPU：3.03%、54.38℃、3270.08MHz，GPU：5.02%
功率：限制15瓦、实际14.90瓦，CPU：2.86%、55.25℃、3535.22MHz，GPU：5.06%
功率：限制16瓦、实际14.90瓦，CPU：2.62%、55.88℃、3654.79MHz，GPU：4.82%
功率：限制17瓦、实际15.34瓦，CPU：2.08%、56.63℃、3340.78MHz，GPU：4.96%
功率：限制18瓦、实际15.08瓦，CPU：2.58%、57.00℃、3169.22MHz，GPU：4.78%
功率：限制19瓦、实际17.49瓦，CPU：3.05%、58.38℃、3169.22MHz，GPU：5.00%
功率：限制20瓦、实际15.14瓦，CPU：3.01%、58.13℃、3556.01MHz，GPU：4.54%
功率：限制21瓦、实际16.50瓦，CPU：3.27%、58.75℃、4041.58MHz，GPU：4.84%
功率：限制22瓦、实际15.32瓦，CPU：4.28%、58.63℃、3169.22MHz，GPU：4.74%
功率：限制23瓦、实际15.30瓦，CPU：3.27%、58.63℃、3714.06MHz，GPU：4.94%
功率：限制24瓦、实际16.21瓦，CPU：3.38%、59.00℃、4148.68MHz，GPU：4.89%
功率：限制25瓦、实际15.29瓦，CPU：1.85%、58.75℃、3169.22MHz，GPU：4.63%
功率：限制26瓦、实际15.44瓦，CPU：2.77%、58.75℃、3864.82MHz，GPU：4.75%
功率：限制27瓦、实际14.94瓦，CPU：2.75%、58.63℃、2975.82MHz，GPU：4.57%
功率：限制28瓦、实际14.70瓦，CPU：2.37%、58.63℃、3714.06MHz，GPU：4.71%
功率：限制29瓦、实际14.59瓦，CPU：2.67%、58.50℃、3753.57MHz，GPU：4.71%
功率：限制30瓦、实际17.01瓦，CPU：4.29%、59.63℃、3169.22MHz，GPU：4.78%
```

## CPU 满载使用

### 测试内容

1. AIDA64 运行 Stress FPU

### 关闭睿频

```text
功率：限制1瓦、实际5.76瓦，CPU：100.00%、52.50℃、399.27MHz，GPU：3.36%
功率：限制2瓦、实际5.29瓦，CPU：100.00%、51.13℃、399.27MHz，GPU：4.37%
功率：限制3瓦、实际5.30瓦，CPU：100.00%、50.13℃、399.27MHz，GPU：6.30%
功率：限制4瓦、实际5.40瓦，CPU：99.96%、49.50℃、399.27MHz，GPU：7.12%
功率：限制5瓦、实际5.39瓦，CPU：99.96%、49.00℃、399.27MHz，GPU：4.89%
功率：限制6瓦、实际5.97瓦，CPU：100.00%、48.88℃、608.63MHz，GPU：3.03%
功率：限制7瓦、实际7.00瓦，CPU：100.00%、49.00℃、835.97MHz，GPU：2.35%
功率：限制8瓦、实际8.01瓦，CPU：100.00%、49.38℃、998.18MHz，GPU：2.24%
功率：限制9瓦、实际9.03瓦，CPU：100.00%、49.88℃、1183.56MHz，GPU：2.11%
功率：限制10瓦、实际9.93瓦，CPU：100.00%、50.50℃、1397.45MHz，GPU：2.10%
功率：限制11瓦、实际10.69瓦，CPU：100.00%、50.75℃、1397.45MHz，GPU：2.63%
功率：限制12瓦、实际10.89瓦，CPU：100.00%、50.88℃、1397.45MHz，GPU：2.31%
功率：限制13瓦、实际12.57瓦，CPU：100.00%、51.25℃、1397.45MHz，GPU：2.11%
功率：限制14瓦、实际13.80瓦，CPU：100.00%、52.00℃、1637.01MHz，GPU：2.01%
功率：限制15瓦、实际15.03瓦，CPU：100.00%、52.88℃、1816.69MHz，GPU：2.13%
功率：限制16瓦、实际16.04瓦，CPU：100.00%、53.88℃、2096.18MHz，GPU：2.42%
功率：限制17瓦、实际17.04瓦，CPU：100.00%、54.88℃、2220.95MHz，GPU：2.11%
功率：限制18瓦、实际18.03瓦，CPU：100.00%、55.88℃、2320.77MHz，GPU：2.04%
功率：限制19瓦、实际19.04瓦，CPU：100.00%、57.00℃、2345.72MHz，GPU：1.80%
功率：限制20瓦、实际20.05瓦，CPU：100.00%、58.13℃、2445.54MHz，GPU：1.81%
功率：限制21瓦、实际21.04瓦，CPU：100.00%、59.25℃、2420.58MHz，GPU：1.93%
功率：限制22瓦、实际22.05瓦，CPU：100.00%、60.50℃、2470.49MHz，GPU：1.83%
功率：限制23瓦、实际23.05瓦，CPU：100.00%、61.75℃、2676.37MHz，GPU：1.94%
功率：限制24瓦、实际24.04瓦，CPU：100.00%、62.88℃、2735.63MHz，GPU：2.00%
功率：限制25瓦、实际25.05瓦，CPU：100.00%、64.25℃、2695.08MHz，GPU：2.02%
功率：限制26瓦、实际26.06瓦，CPU：100.00%、65.63℃、2869.76MHz，GPU：1.76%
功率：限制27瓦、实际27.06瓦，CPU：100.00%、67.00℃、2900.96MHz，GPU：1.87%
功率：限制28瓦、实际28.05瓦，CPU：100.00%、68.25℃、2944.63MHz，GPU：2.00%
功率：限制29瓦、实际29.08瓦，CPU：100.00%、69.63℃、3022.61MHz，GPU：1.85%
功率：限制30瓦、实际30.07瓦，CPU：100.00%、71.00℃、3069.40MHz，GPU：2.05%
```

### 开启睿频

```text
功率：限制1瓦、实际6.15瓦，CPU：100.00%、63.75℃、399.27MHz，GPU：3.09%
功率：限制2瓦、实际5.58瓦，CPU：100.00%、59.88℃、399.27MHz，GPU：3.00%
功率：限制3瓦、实际5.54瓦，CPU：100.00%、57.63℃、399.27MHz，GPU：3.35%
功率：限制4瓦、实际5.54瓦，CPU：100.00%、56.13℃、399.27MHz，GPU：3.31%
功率：限制5瓦、实际5.47瓦，CPU：100.00%、55.13℃、399.27MHz，GPU：3.02%
功率：限制6瓦、实际5.94瓦，CPU：100.00%、54.25℃、543.18MHz，GPU：2.97%
功率：限制7瓦、实际7.00瓦，CPU：100.00%、53.88℃、736.16MHz，GPU：2.52%
功率：限制8瓦、实际8.01瓦，CPU：100.00%、53.75℃、998.53MHz，GPU：2.34%
功率：限制9瓦、实际8.96瓦，CPU：100.00%、53.88℃、1212.07MHz，GPU：2.09%
功率：限制10瓦、实际9.99瓦，CPU：100.00%、54.25℃、1397.45MHz，GPU：2.05%
功率：限制11瓦、实际10.72瓦，CPU：100.00%、54.25℃、1397.45MHz，GPU：2.25%
功率：限制12瓦、实际10.96瓦，CPU：100.00%、54.13℃、1397.45MHz，GPU：2.88%
功率：限制13瓦、实际12.28瓦，CPU：100.00%、54.13℃、1397.45MHz，GPU：1.94%
功率：限制14瓦、实际13.86瓦，CPU：100.00%、54.63℃、1617.05MHz，GPU：1.99%
功率：限制15瓦、实际15.00瓦，CPU：100.00%、55.25℃、1696.90MHz，GPU：1.90%
功率：限制16瓦、实际16.03瓦，CPU：100.00%、56.00℃、1976.39MHz，GPU：1.95%
功率：限制17瓦、实际17.03瓦，CPU：100.00%、56.75℃、2171.04MHz，GPU：2.10%
功率：限制18瓦、实际18.03瓦，CPU：100.00%、57.63℃、2245.90MHz，GPU：1.89%
功率：限制19瓦、实际19.03瓦，CPU：100.00%、58.50℃、2270.86MHz，GPU：1.90%
功率：限制20瓦、实际20.04瓦，CPU：100.00%、59.50℃、2470.49MHz，GPU：1.94%
功率：限制21瓦、实际21.05瓦，CPU：100.00%、60.50℃、2470.49MHz，GPU：1.81%
功率：限制22瓦、实际22.06瓦，CPU：100.00%、61.63℃、2573.43MHz，GPU：1.77%
功率：限制23瓦、实际23.04瓦，CPU：100.00%、62.75℃、2695.08MHz，GPU：1.93%
功率：限制24瓦、实际24.06瓦，CPU：100.00%、64.00℃、2720.04MHz，GPU：1.96%
功率：限制25瓦、实际25.06瓦，CPU：100.00%、65.13℃、2819.86MHz，GPU：1.81%
功率：限制26瓦、实际26.06瓦，CPU：100.00%、66.50℃、2863.53MHz，GPU：1.92%
功率：限制27瓦、实际27.06瓦，CPU：100.00%、67.63℃、2894.72MHz，GPU：2.01%
功率：限制28瓦、实际28.07瓦，CPU：100.00%、68.88℃、2969.58MHz，GPU：1.96%
功率：限制29瓦、实际29.07瓦，CPU：100.00%、70.13℃、2994.54MHz，GPU：1.85%
功率：限制30瓦、实际30.05瓦，CPU：100.00%、71.50℃、2894.72MHz，GPU：1.90%
```
