<?php

$inputDataArray = file('input.txt');

$currentPosition = 0;
$lotCount = $inputDataArray[$currentPosition++];
$lotData = array();

if (count($inputDataArray) > 0 && $lotCount > 0)
{
    for($i = $currentPosition; $i <= $lotCount; ++$i, ++$currentPosition)
    {
        $stringDataArray = explode(' ', $inputDataArray[$i]);
		$gameId = $stringDataArray[0];
        $lotData[$gameId] = array("lot_amount" => $stringDataArray[1], "lot_team" => $stringDataArray[2]);
    }
	
	$gamesCount = $inputDataArray[$currentPosition++];
	if ($gamesCount > 0)
	{
		for($i = $currentPosition; $i < $currentPosition + $gamesCount; ++$i)
		{
			$stringDataArray = explode(' ', $inputDataArray[$i]);
			$gameId = $stringDataArray[0];
			
			//if (in_array($gameId, $lotData)){
				$winner_team = $stringDataArray[4];
				$tmp = array("L" =>$stringDataArray[1] , "R" => $stringDataArray[2], "D" => $stringDataArray[3], "win_team" => $winner_team);
				
				$lotData[$gameId] = array_merge($tmp, $lotData[$gameId]);
				
				$lotData[$gameId]["result"] = ord($lotData[$gameId]["lot_team"]) == ord($winner_team)
					? $lotData[$gameId]["lot_amount"] * $lotData[$gameId][chr(ord($winner_team))] - $lotData[$gameId]["lot_amount"]
					: $lotData[$gameId]["lot_amount"] * (-1);
					
			//}
		}
	}
	
	$result = 0;
	
	foreach ($lotData as $lotInfo){
		$result += $lotInfo["result"];
	}
	echo ($result);
}