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
  //Read serial
  char Message = Serial.read();
  switch (Message)
  {
  case 'n':
    if (receive <= now || cntPlayer <= now + 1)
      break;
    for (int i = 0; i < cntPlayer; i++)
      digitalWrite(playerStatus[i].Output, LOW);
    now++;
    Serial.println("Successful next display");
    break;
  case 'r':
    for (int i = 0; i < cntPlayer; i++)
    {
      digitalWrite(playerStatus[i].Output, LOW);
      playerStatus[i].Finish = 0;
      solver[i] = -1;
    }
    now = 0;
    receive = 0;
    Serial.println("Successful reset");
    break;
  }

  //Check the pin
  for (int i = 0; i < cntPlayer; i++)
  {
    int NowStatus = digitalRead(playerStatus[i].Input);
    if (playerStatus[i].Status != NowStatus && playerStatus[i].Finish == 0)
    {
      solver[receive] = i;
      receive++;
      playerStatus[i].Finish = 1;
      Serial.print("Push:");
      Serial.println(i);
    }
    playerStatus[i].Status = NowStatus;
  }

  //Lamp on
  if (solver[now] != -1)
  {
    digitalWrite(playerStatus[solver[now]].Output, HIGH);
    Serial.print("Ans:");
    Serial.println(solver[now]);
    solver[now] = -1;
  }
}
