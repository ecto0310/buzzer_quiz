const int cntPlayer = 5;

//Structure of player state
struct PlayerStatus
{
  const int Input, Output;
  int Status, Finish;
};

PlayerStatus playerStatus[5] = {{2, 3, -1, 0}, {4, 5, -1, 0}, {6, 7, -1, 0}, {8, 9, -1, 0}, {10, 11, -1, 0}};
int solver[5] = {-1, -1, -1, -1, -1};
int now = 0, receive = 0;

void setup()
{
  //Set serial
  Serial.begin(9600);

  //Set player
  for (int i = 0; i < cntPlayer; i++)
  {
    pinMode(playerStatus[i].Input, INPUT);
    pinMode(playerStatus[i].Output, OUTPUT);
  }
}

void loop()
{
}
