using UnityEngine;

//メモ1枚分の情報（Mystery1のパスワードの1桁）
public class MemoInfo
{
    public string number; //メモに書かれる数字
    public Color color;   //メモの文字色（Mystery1の入力欄の色と対応）

    public MemoInfo(string number, Color color)
    {
        this.number = number;
        this.color = color;
    }
}

//Mystery1のパスワードを4枚のメモに分けて管理する
public class MemoManager : MonoBehaviour, IResetInterface
{
    public static MemoManager memoInstance;
    public const int MemoCount = 4;

    //メモとMystery1の入力欄に使う色（赤・オレンジ・緑・黄）
    //原色を避け、彩度を抑えたマットな色にしている
    static readonly Color[] MemoColors =
    {
        new Color(0.75f, 0.31f, 0.30f), //赤（#BF4F4D）
        new Color(0.85f, 0.53f, 0.29f), //オレンジ（#D9874A）
        new Color(0.50f, 0.64f, 0.42f), //緑（#80A36B）
        new Color(0.86f, 0.77f, 0.43f)  //黄（#DBC46E）
    };

    //ゲーム内に配置するメモ（要素番号＝メモ番号）。未配置のメモはnullのままでよい
    [SerializeField] MemoObject[] memoObjects = new MemoObject[MemoCount];

    Color[] digitColors = new Color[MemoCount]; //入力欄（桁）ごとの色
    int[] memoToDigit = new int[MemoCount];     //メモ番号→何桁目の数字を書くか

    private void Awake()
    {
        if (memoInstance is null)
        {
            memoInstance = this;
        }
    }

    //ゲーム開始ごとに色とメモの割り当てをランダムに決める
    //Mystery1のパスワード作成後に呼ぶこと
    public void InitialzedObject()
    {
        digitColors = (Color[])MemoColors.Clone();
        Shuffle(digitColors);

        for (int i = 0; i < MemoCount; i++)
        {
            memoToDigit[i] = i;
        }
        Shuffle(memoToDigit);

        foreach (var memo in memoObjects)
        {
            if (memo != null)
            {
                memo.InitialzedObject();
            }
        }
    }

    //Mystery1の入力欄（桁）の色を返す
    public Color GetDigitColor(int digitIndex)
    {
        return digitColors[digitIndex];
    }

    //メモ番号に対応するメモの内容を返す
    public MemoInfo GetMemo(int memoIndex)
    {
        int digitIndex = memoToDigit[memoIndex];
        string number = Mystery1Manager.passwordInstance.GetDigit(digitIndex);
        return new MemoInfo(number, digitColors[digitIndex]);
    }

    //配列の並びをランダムに入れ替える（Fisher-Yates）
    static void Shuffle<T>(T[] array)
    {
        for (int i = array.Length - 1; i > 0; i--)
        {
            int j = Random.Range(0, i + 1);
            (array[i], array[j]) = (array[j], array[i]);
        }
    }
}
