## random-avatar

[![Build status](https://ci.appveyor.com/api/projects/status/0y937m1x8g1w6ic6/branch/master?svg=true)](https://ci.appveyor.com/project/chsword/random-avatar/branch/master)
[![CodeFactor](https://www.codefactor.io/repository/github/chsword/random-avatar/badge)](https://www.codefactor.io/repository/github/chsword/random-avatar)

## For dotnet core / docker 

https://github.com/random-avatar/random-avatar

```
docker pull chsword/random-avatar:v2.0-alpine
docker run -d -p 80:80 chsword/random-avatar:v2.0-alpine
```
**Docker的环境变量 **
```
RANDOM_AVATAR_HOME：是否显示首页，默认值 true ，取值 true|false
RANDOM_AVATAR_SYMMETRY：生成的图像是否对称，默认值 true，取值 true|false
RANDOM_AVATAR_SIZE：生成的图像大小，默认值 100，取值 int
RANDOM_AVATAR_PADDING：生成的图像边距，默认值 2，取值 int
RANDOM_AVATAR_BLOCK_COUNT：生成的图像分成多少个横纵列，默认值 6，取值 int > = 3
```
```
* 注意 SZIE-PADDING 需要与 BLOCK_COUNT 是整除关系，否能可能出现边距不一致的情况
即 MOD(SZIE-PADDING,BLOCK_COUNT)==0
```

## 说明，Description

您可以通过以下类似 URL 进行访问，You can use the following URL to access the image：

http://url/avatar/x

生成图片的代码片断，The following are pieces of code to generate images：

`var bytes = RandomAvatarBuilder.Build(100).SetPadding(5).ToBytes();`

`var image = RandomAvatarBuilder.Build(100).SetPadding(5).ToImage();`


## 示例，Example

非对称 dissymmetry

![](https://raw.githubusercontent.com/chsword/random-avatar/master/example/1.png)
![](https://raw.githubusercontent.com/chsword/random-avatar/master/example/3.png)
![](https://raw.githubusercontent.com/chsword/random-avatar/master/example/4.png)

对称 symmetry

![](https://raw.githubusercontent.com/chsword/random-avatar/master/example/5.png)
![](https://raw.githubusercontent.com/chsword/random-avatar/master/example/6.png)
![](https://raw.githubusercontent.com/chsword/random-avatar/master/example/7.png)

### 其它特性 Other feature

如果需要固定生成的功能可以访问

url/face/seed

如

`url/face/chsword@126.com`

### 引用，Reference:

https://github.com/hackrslab/random-avatar
