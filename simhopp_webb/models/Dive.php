<?php
class Dive
{
    public $id;
    public $code;
    public $points;
    public $multiplier;
    public $name;
    public $score;
    public $finalScore;

    public function __construct($id, $code, $multiplier, $name, $points, $finalScore)
    {
        $this->id = $id;
        $this->code = $code;
        $this->multiplier = $multiplier;
        $this->name = $name;
        $this->points = $points;
        $this->finalScore = $finalScore;
    }
}