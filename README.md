# Circle-Rotate
通过转盘的数量,来计算需要旋转到的角度.我这里是有 12个 旋转的位置, 故 360/12 = 30..  所以,以30度为一个单位,进行偏移计算
核心思路:设置偏转角所要停留的位置,将其偏移角进行记录
```
float SetRotateAngle(int value)
    {
        float rotateAngle = .0f;
        switch (value)
        {
            case 0:
                {
                    rotateAngle = 0.0f;
                }
                break;
            case 330:
                {
                    rotateAngle = 330.0f;
                }
                break;
            case 300:
                {
                    rotateAngle = 300.0f;
                }
                break;
            case 270:
                {
                    rotateAngle = 270.0f;
                }
                break;
            case 240:
                {
                    rotateAngle = 240.0f;
                }
                break;
            case 210:
                {
                    rotateAngle = 210.0f;
                }
                break;
            case 180:
                {
                    rotateAngle = 180.0f;
                }
                break;
            case 150:
                {
                    rotateAngle = 150.0f;
                }
                break;
            case 120:
                {
                    rotateAngle = 120.0f;
                }
                break;
            case 90:
                {
                    rotateAngle = 90.0f;
                }
                break;
            case 60:
                {
                    rotateAngle = 60.0f;
                }
                break;
            case 30:
                {
                    rotateAngle = 30.0f;
                }
                break;
            default:
                break;
        }
        return rotateAngle;
    }            
```
