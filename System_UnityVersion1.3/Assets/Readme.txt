/*はじめに*/
使いやすいFadeSystemがあり共有したいと思ったので、
共有します。自分なりにわかりやすく説明しているので、
参考になれば幸いです。



/*注意事項*/
データが消えたりしても一切の責任を負いません。
使用する際は自己責任でお願いします。
分からないことがあればDiscordのDMで直接聞いてくれれば、
できる限りのサポートはします。



/*Scene1について*/
1280 × 720 に解像度を変更してください。
ビルド設定でScene1とScene2をアタッチしてください。
画面をクリックすると1秒かけて画面を暗くし、Scene2に移行します。



/*ProjectにFadeSystemの導入方法*/
Prefabsフォルダの中にあるFadeCanvasをヒエラルキーにドラッグ&ドロップしてください。
FadeCanvasにアタッチされているFadeImage.csの中にある
Mask Textureにルール画像をアタッチしてください。
ルール画像については/*ルール画像について*/を参照してください。

FadeInをしたい場合は、空のオブジェクトを用意しFadeIn.csをアタッチしてください。
FadeIn.csの中にあるFadeの欄にFadeCanvasをアタッチしてください。
現在FadeIn.csは画面をクリックすると1秒かけてFadeInし、終わったらScene2へ移行します。
詳しくは/*FadeIn.csについて*/を参照してください。

FadeOutをしたい場合は、FadeCanvasにFadeOut.scをアタッチしてください。
FadeOut.csの中にあるFadeの欄にFadeCanvasをアタッチしてください。
もしFadeCanvasの中にあるFade.csのStartFadeがtrueになっていなければ
インスペクターからクリックしてtrueにしてください。
Sceneの開始と同時にFadeOutを1秒かけて行います。
詳しくは/*FadeOut.cs*/を参照してください。



/*ルール画像について*/
Fadeをするためのパターンデータです。
ルール画像は各自ダウンロードしてください。(ほんとは用意する予定だったけど重かった)
使う際はTextureTypeをSingleChannelにし、AlphaSourceをFromGrayScaleにしてから
使ってください。配布サイトのリンクを用意しましたがネットで検索するとたくさんあるので、
自分で探してくるのもいいと思います。

ルール画像配布サイト
https://4you.bz/rule



/*FadeInについて*/
FadeInするためのスクリプトです。

[SerializeField] Fade fade;
でFadeCanvasを参照しています。

fade.FadeIn(1f);
で1秒かけてFadeInします。

fade.FadeIn(1f, () => SceneManager.LoadScene("Scene2"));
で1秒かけてFadeInし、終わったらScene2に移行します。

空のオブジェクトを用意しFadeIn.csをアタッチしてください。
FadeIn.csの中にあるFadeの欄にFadeCanvasをアタッチしてください。
In();を呼び出すとFadeInします。



/*FadeOutについて*/
FadeOutするためのスクリプトです。

[SerializeField] Fade fade;
でFadeCanvasを参照しています。

fade.FadeOut(1f);
で1秒かけてFadeOutします。

FadeOutするときは、FadeCanvasにアタッチして、
fadeにFadeCanvasをアタッチしてください。
また、FadeCanvasにアタッチされているFade.csのStarFadeをtrueにしてください。



/*参考サイト*/
https://4you.bz/rule
http://kerotan-factory.xblog.jp/article/463659352.html