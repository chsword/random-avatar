## random avatar


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

### 引用，Reference:

https://github.com/hackrslab/random-avatar
