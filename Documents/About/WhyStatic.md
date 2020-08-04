# 静的コード生成の利点

筆者が今まで試したDIコンテナは実行時にリフレクションを利用してインスタンスを生成します。
これに筆者は不満点がいくつかありました。

Deptorygenは、そういった不満点を解消できないか挑戦するプロジェクトです。

Deptorygenを使用する利点のほとんどは、
インスタンスを生成するためのコードを静的に生成することに基づいています。
静的にコード生成をすることでどのようなメリットが得られるか紹介します。

## 不満点の解消: 不透明さ

動的に依存関係を判断してインスタンスを生成する場合、
その手順は実行時において動的にコードを生成することによって決まります。
こうなると、プログラマーはインスタンスが実際にどのような手順で生成されているのかを知ることができません。

Deptorygenでは、インスタンスを生成するコードが静的にコード生成されるため、そのコードを見ればどのような手順で生成されているのかを理解することができます。

[基本的な使い方](../Guides/BasicStyle.md)

## 不満点の解消: コンパイルエラーが出ない

動的に依存関係を判断してインスタンスを生成する場合、
依存関係を解決する手段が実行時に決まるということなので、
実際には依存関係を解決できないような設定でDIコンテナが使用されている場合に
コンパイルエラーを出すことができません。

Deptorygenを用いてファクトリークラスを生成すると、
依存関係の解決が不可能であった型に対しては無効なコードが生成され、コンパイルエラーとなります。

ただし、依存先のインスタンスを生成することができないことにより依存関係の解決が不可能であった場合は
ファクトリークラス自体は有効なコードが生成されます。
その代わり、足りない依存先がコンストラクタの引数でもって利用者に対して要求されます。
この引数にインスタンスを渡したくない場合はファクトリーも生成できないことになるため、
プログラマーはファクトリークラスに対して十分に型の情報を伝える必要があることに気づくことができます。

[コンストラクタで意外な引数を要求されたら](../Guides/Constructor.md)

## 不満点の解消: 追加の引数を与えて生成したい

動的に依存関係を判断してインスタンスを生成するDIコンテナでは、
実際にインスタンスを生成するタイミングで初めて得られるような情報を追加で引数に渡して、
適切に設定されたインスタンスを生成できるものもあります。
しかし、こうして与える追加の引数についてコンパイル時に型チェックをしてもらうことは困難です。

DeptorygenでもそうしたDIコンテナと同様に、
インスタンスを生成するときに追加の引数を渡すことができます。
ただし、依存関係を解決するコードは静的に生成されているため、
追加で渡す引数も必ず型チェックの対象となります。

[解決メソッドに直接オブジェクトを渡す](../Samples/Parameterize.md)

## 不満点の解消: インスタンスの寿命管理

DIコンテナにおいてインスタンスの寿命を直感的に管理するのは難しい課題です。
筆者の利用したものだと、`Singleton`, `Scope`, `Transient` といった3つ程度の区分に分かれ、
あとはDIコンテナ独自のクラス構造を駆使してスコープや寿命を管理します。
例えばGenericHostのDIコンテナであれば、`ServiceProvider`のインスタンスが1つのスコープに対応しています。

Deptorygenでは、インスタンスの寿命はそのインスタンスをキャッシュしているファクトリーが基準となります。
ファクトリークラスのインスタンスはstaticなものではないため、
ファクトリーによって生成されるようなインスタンスとまったく同様に取りまわすことができます。

Deptorygenでのインスタンスの寿命は2種類です。`Cached`……つまりファクトリーそのものと同等か、`Transient`……生成するたびに違うものか、です。

partialクラスの性質を生かしてファクトリー自体をシングルトンにするのも自由です。
その場合、寿命が`Cached`であるインスタンスはGenericHostでいう`Singleton`と同じように扱えるでしょう。

他にも、ファクトリークラスを生成する種となる複数のインターフェース定義に対して継承や包含の関係を持たせれば、
複数のファクトリー間で寿命を共有したり、特定のインスタンスを生成する権利を持つクラスを限定するなどの使い方ができたり、
DIコンテナを使わない場合と同じくらいに寿命とスコープを柔軟に管理することができます。

[ファクトリーを別のアセンブリに提供する](../Guides/ExportType.md)

[依存関係の解決に別のファクトリーも利用する(キャプチャ)](../Samples/Capture.md)