<?php
class Point
{
    public $id;
    public $value;
    public $judgeID;

    public function __construct($id, $value, $judgeID)
    {
        $this->id = $id;
        $this->value = $value;
        $this->judgeID = $judgeID;
    }
}