/*はじめに*/
制作において、ステータスやテキストのデータを変更したい場合、
どの変数を変更すればよいか分からないことなどはよくあると思います。
そのため、コメント文や変数名を分かりやすくするのが大切ですが、
それでもプログラムが得意でない人やプログラマー以外の職種の人には変更が難しいと思います。
そこで、誰でも簡単にデータを変更できるようにGoogleスプレッドシート(GSS)を使用し、
入力したデータをUnityに送信するシステムを作成しました。
参考にしていただければ幸いです。



/*注意事項*/
データが消えたりしても一切の責任を負いません。
使用する際は自己責任でお願いします。



/*GeneralParameter.assetの使用方法*/
GeneralParameter.assetをアタッチすれば使用することができます。
詳しくは付属されているSampleSceneとDebugText.csをご覧ください。



/*GSSEditorの使用方法*/
*GSSEditorの開き方*
WindowからGoogleSpreadSheetEditorを開いてください。

*GSSを開く*
Googleスプレッドシートを開くボタンです。
PathScriptableObjectに設定したGSSを開きます。

*変数の追加*
変数を追加するために書き換える必要がある
スクリプトを開くボタンです。
PathScriptableObject.assetに設定したスクリプトを開きます。
変数を追加する方法は＜変数を追加する方法＞をご覧ください。

*パスの変更*
パスを変更するためのPathScriptableObjectを開くボタンです。
パスやURLが変更された際はこちらから書き換えてください。

*データの反映*
データを反映するボタンです。
シート名の入力欄に書かれているシートのデータを反映します。
シート名がない場合はエラーが発生します。

*シート名*
反映させたいシート名を記入する欄です。
存在しないシート名を入力すると、
反映ボタンを押した際エラーが発生します。



/*PathScriptableObject.assetの設定*/
PathScriptableObject.assetにパスやURLの設定を行ってください。

GSSのURLにはGoogleスプレッドシートの右上にある共有ボタンを押し、
左下にあるリンクをコピーのボタンを押すと入手できるリンクを記入してください。

GASのURLにはGoogleAppsScriptのデプロイ時に入手できる
ウェブアプリのURLを記入してください。
詳しくは＜Googleスプレッドシートの設定＞をご覧ください。

GeneralParameter.assetのパスにはUnity内のGeneralParameter.assetのパスを入力してください。
基本触らなくていいですが、GeneralParameter.assetの場所を変更した際は変更してください。

変数を追加するためのスクリプトのパスにはWebData.cs, LoadGSS.cs, GeneralParameter.csの
三つのパスを入力してください。
基本触らなくていいですが、スクリプトの場所を変更した際は変更してください。



/*変数を追加する方法*/
変数を追加する際は、以下の手順に沿って追加してください。

1. GSSEditorの中にある*変数の追加*と書かれたボタンを押すか、
   WebData.cs, LoadGSS.cs, GeneralParameter.csの三つを開いてください。

2. WebData.csはGoogleスプレッドシートのA列に入力した変数名と同じ
   名前でstring型の変数を作成してください。

3. LoadGSS.csはReflectData()の中身を書き換える必要があります。
   GeneralParameter.csの変数にWebData.csの変数を代入してください。
   変数の型によって書き換える必要があるので以下を参考に書いてください。

   generalParameter.intParam = (int)float.Parse(data.key_0);              //int型の場合
   generalParameter.floatParam = float.Parse(data.key_1);                 //float型の場合
   generalParameter.stringParam = data.key_2;                             //string型の場合
   generalParameter.boolParam = data.key_3 == "true" ? true : false;      //bool型の場合

4. GeneralParameter.csはゲーム内で使用する変数を作成してください。
   必ずpublicにしてください。変数名や型は自由です。



/*Googleスプレッドシートの設定*/
デフォルトで設定されているGoogleスプレッドシートを参考に、
各自で新規スプレッドシートを作成してください。
A列には変数名、B列にはその変数に入れたい値を入力してください。
2行目から読み取りを開始します。1行目は反映されません。

次に、Unityにデータを送信するスクリプトを書いてください。
拡張機能からAppsScriptを選択し、コード.gsを編集していきます。
記入するコードは長いので付属されているGASCodeSample.txtをご覧ください。

記入することができたら、右上にあるデプロイという青色のボタンを押し、
新しいデプロイを選択してください。
その後、種類の選択からウェブアプリを選択し、アクセスできるユーザーを
全員にしデプロイを押してください。
デプロイ後に表示されるウェブアプリのURL( https://script.google.comで始まるやつ)をコピーし、
Unity内にあるPathScriptableObject.assetのGASのURLの欄に記入してください。
PathScriptableObject.assetはGSSEditorのパスの変更ボタンを押すと開けます。



/*更新履歴*/
v1.0.0 GSSEditor完成		24.01.14.00.43



/*参考サイト*/
https://tanisugames.com/unity-google-spreadsheet-integration/
https://qiita.com/TakashiHamada/items/198c520b815efb594a5c
https://qiita.com/Yami_37/items/b4ed2bd2e20ffe7dfbca
https://zenn.dev/kumas/books/325ed71592f6f5/viewer/78e9eb