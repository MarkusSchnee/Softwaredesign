using System;

namespace L06{

    public class Player
    {
        public int score;
        public string playerName;

        public void calculatescore(bool truth)
        {
            if(truth == true){
                score = score +1;
            }else{
                score = score -1;
            }
        }
    }
}