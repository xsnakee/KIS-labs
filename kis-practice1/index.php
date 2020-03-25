<?php

$inputDataArray = file('input.txt');
$tripCount = $inputDataArray[0];
$inputDatesArray = array_slice($inputDataArray, 1, $tripCount);

$outputFile = fopen('output.txt', 'w');
$dateTimeFormat = "d.m.Y_H:i:s";

if (count($inputDatesArray) > 0 && $tripCount > 0)
{
    for($i = 0; $i < $tripCount; ++$i)
    {
        $stringDataArray = explode(' ', $inputDatesArray[$i]);
        $gtmTimeZone = $inputDatesArray[1] * 100;

        $startPointDateTime = DateTime::createFromFormat($dateTimeFormat, $stringDataArray[0], new \DateTimeZone("UTC"));
        $startPointTimeZone = (int)-$stringDataArray[1]." hours";
        $startPointDateTime->modify($startPointTimeZone);

        $endPointDate = DateTime::createFromFormat($dateTimeFormat, $stringDataArray[2], new \DateTimeZone("UTC"));
        $endPointTimeZone = (int)-$stringDataArray[3]." hours";
        $endPointDate->modify($endPointTimeZone);

        $resultTime = $endPointDate->getTimestamp() - $startPointDateTime->getTimestamp();
        fwrite($outputFile, $resultTime);
		fwrite($outputFile, '\n');
    }
}

fclose($outputFile);