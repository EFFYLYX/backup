using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Model : MonoBehaviour
{
    public const int MAX_DEBRIS = 5;
    public const int STORAGE_ROWS = 5;
    public const int MAX_ROWS = 12;
    public const int MAX_COLLUMS = 5;
    public Shape[,] map = new Shape[MAX_COLLUMS, MAX_ROWS];
    public Dictionary<Vector2, Shape> badguys = new Dictionary<Vector2, Shape>();

    int[] top = new int[5];

    public int dh = 0;
    public int ipg = 0;
    public int s = 0;

   public int r = 0;
   public  int b = 0;
    public int g = 0;
   public  int rgb = 0;

    public bool isDataUpdate = false;
   



    public bool IsValidMapPosition(Transform t)
    {
        Vector2 pos = t.position.Round();
        //Debug.Log(t.position.toString());

        if (IsInsideMap(pos) == false)
        {
            return false;
        }


        int x = (int)pos.x + 2;
        int y = (int)pos.y + 5;

        if (map[x,y] != null)
        {
            return false;
        }


        //if (badguys.ContainsKey(pos))
        //{
        //    Debug.Log("contains");

        //    if (badguys[pos] != null) { return false; }

        //}



        //if(badguys.ContainsKey(new Vector2(0, 0)))
        //{
        //    if (badguys[new Vector2(0,0)] != null) { return false; }
        //}

        //badguys.Add(pos, t);
        //foreach(Transform child in t)
        //{
        //    if(child.tag != "Block")
        //    {
        //        continue;


        //    }

        //    Vector2 pos = child.position.Round();
        //    Debug.Log("pos:" + pos.x.ToString()+","+pos.y.ToString());

        //    if (IsInsideMap(pos) == false)
        //    {
        //        return false;
        //    }





        //    if (map[(int)pos.x, (int)pos.y] != null)
        //    {
        //        return false;
        //    }
        //}


        return true;
    }

    public void PlaceShape2(Vector2 pos, Shape shape)
    {
        int x = (int)pos.x + 2;
        int y = (int)pos.y + 5;

        map[x, y] = shape;

        //CheckVertical();
        //CheckHorizontal();
    }

    public void PlaceShape(Vector2 pos, Shape shape)
    {
       
        int x = (int)pos.x + 2;
        int y = (int)pos.y + 5;

        map[x, y] = shape;

        //if (top[x] == null)
        //{
        //    top[x] = y;
        //}

        top[x] = y;
       
        CheckVertical();
        CheckHorizontal();
    }

    private bool IsInsideMap(Vector2 pos)
    {
        return pos.x >= -2 && pos.x <= 2 && pos.y >=-5 && pos.y<=6;
    }
    private void checkMap()
    {


    }

    public bool CheckWin()
    {
        if (s >= 100)
        {
            return true;
        }
        return false;
    }


    //public void DestroyDebris(Shape s)
    //{

    //}



    public void CheckHorizontal()
    {
        int h_score = 0;


        for (int i = 0; i < MAX_ROWS; i++)
        {
          
            for (int j = 0; j < MAX_COLLUMS-2; j++)
            {
                List<string> RGBs = new List<string>();

                Shape now = map[j,i];
                Shape next = map[j + 1, i];
                Shape nextnext = map[j + 2, i];



                if (now != null && next != null && nextnext != null)
                {

                    RGBs.Add(now.tag);
                    RGBs.Add(next.tag);
                    RGBs.Add(nextnext.tag);


                        //if (RGBs.Contains("Blue") && RGBs.Contains("Red") && RGBs.Contains("Green"))
                        //{

                        if (now.tag=="Red" && next.tag=="Green" && nextnext.tag=="Blue")
                        {
                            //if (nextnext.scoreH ==false || now.scoreH == false)
                            //{
                            h_score += 15;

                            s += 15;

                            rgb += 1;

                            ipg += 1;

                        //    now.scoreH = true;
                        //    next.scoreH = true;
                        //    nextnext.scoreH = true;
                        //}
                            Destroy(now.gameObject);
                            map[j, i] = null;


                            Destroy(next.gameObject);
                            map[j+1, i] = null;

                            Destroy(nextnext.gameObject);
                            map[j+2, i] = null;



                            int[] colums = new int[3];
                            colums[0] = j;
                            colums[1] = j + 1;
                            colums[2] = j + 2;
                            MoveDownAboveRow(colums, i);

                        }
                    

                }


            }
        }

        //Debug.Log("score:" + h_score.ToString());
    }


    public void MoveDownAboveRow(int[] collums, int row)
    {
        List<Shape> temp = new List<Shape>();

        

        foreach(int i in collums)
        {
            
            for(int j= row+1; j <= top[i]; j++)
            {
                map[i, j].MoveDown();

            }
            
            
            map[i, top[i]] = null;
            top[i]--;
        }

        //for (int j = row + 1; j < MAX_ROWS - 1; j++)
        //{
        //    //MoveDownRow(collums, j);
        //    foreach (int i in collums)
        //    {
        //        //if (map[i, j] != null)
        //        //{
        //        //    temp.Add(map[i, j]);
        //        //}
        //        int x = -1;
        //        int y = -1;
        //        if (map[i, j] != null && map[i, j + 1] == null)
        //        {
        //            x = i;
        //            y = j;
        //        }
        //        if (map[i, j] != null)
        //        {
        //            map[i, j].MoveDown();
        //            //map[i, j-1] = map[i, j];
        //            //map[i, j].MoveDown();

        //        }

        //        if (x > -1 && y > -1)
        //        {
        //            map[i, j] = null;
        //        }


        //    }



        //}
    }




    public void MoveDownRow(int[] collums, int row)
    {
        foreach (int i in collums)
        {
            if (map[i, row - 1] != null)
            {
                map[i, row - 1] = map[i, row];
                map[i, row] = null;
                map[i, row - 1].MoveDown();
            }

        }
    }



    public bool CheckFull(int x)
    {
        //int count = 0;
        //for (int i = 0; i < MAX_COLLUMS; i++)
        //{
        //    //Shape former = map[i, 0];


        //    //for (int j = 0; j < STORAGE_ROWS; j++)
        //    //{

        //        Shape now = map[i, 4];

        //        if(now != null)
        //        {
        //            return true;
        //        }
        //    //    //if (now.tag == "Debris")
        //    //    //{
        //    //    //    count++;
        //    //    //}


        //    //}
        //}
                Shape now = map[x, 4];

                if(now != null)
                {
                    return true;
                }

        return false;
    }


    public bool CheckDebris()
    {


        int count = 0;
        for (int i = 0; i < MAX_COLLUMS; i++)
        {
            //Shape former = map[i, 0];
            for (int j = 0; j < MAX_ROWS; j++)
            {

                Shape now = map[i, j];
                if (now != null)
                {
                    if (now.tag == "Debris")
                    {
                        count++;
                    }
                }



            }
        }

        if (count >= MAX_DEBRIS-1)
        {
            return true;
        }

        return false;
    }






    public void CheckVertical()
    {
        //foreach(Vector2 k in badguys.Keys)
        //{

        //}
        //Shape[] group = new Shape[3];
        int v_score = 0;
        
        for (int i = 0; i < MAX_COLLUMS;i++)
        {
            //Shape former = map[i, 0];
            for(int j = 0; j < MAX_ROWS-2; j++)
            {
                

                Shape now = map[i, j];
                Shape next = map[i, j + 1];
                Shape nextnext = map[i, j + 2];

                if (now != null && next!=null && nextnext!=null)
                {
                    if (now.tag == next.tag && now.tag == nextnext.tag && nextnext.tag != "Debris" && now.tag !="Debris" && next.tag !="Debris")
                    {
                        //if(nextnext.scoreV ==false)
                        //{
                            v_score += 10;

                            s += 10;
                            ipg += 1;

                            if (now.tag == "Blue")
                            {
                                b += 1;
                            }

                            if (now.tag == "Green")
                            {
                                g += 1;
                            }

                            if (now.tag == "Red")
                            {
                                r += 1;
                            }
                            //Debug.Log("b:" + b.ToString());
                            isDataUpdate = true;

                        //    now.scoreV = true;
                        //    next.scoreV = true;
                        //    nextnext.scoreV = true;
                            

                        //}






                        Destroy(now.gameObject);
                        map[i, j] = null;


                        Destroy(next.gameObject);
                        map[i, j+1] = null;

                        Destroy(nextnext.gameObject);
                        map[i, j + 2] = null;


                        top[i] = j - 1;
                        //if (j > 0)
                        //{
                        //    top[i] = j - 1;
                        //}
                        //else
                        //{
                        //    top[i] = 0;
                        //}



                    }
                }

              
            }
        }

            //Debug.Log("score:"+ v_score.ToString());


    }

    public void ReStart()
    {
        for (int i = 0; i < MAX_COLLUMS; i++)
        {
            //Shape former = map[i, 0];
            for (int j = 0; j < MAX_ROWS; j++)
            {
                if (map[i, j] != null)
                {
                    Destroy(map[i, j].gameObject );
                    map[i, j] = null;
                }


            }
        }

       dh = 0;
    ipg = 0;
    s = 0;

    r = 0;
     b = 0;
     g = 0;
    rgb = 0;



    //map = new Shape[MAX_COLLUMS, MAX_ROWS];
}
    // Start is called before the first frame update
    //void Start()
    //{

    //}

    //// Update is called once per frame
    //void Update()
    //{

    //}
}
