<?php
class Contest
{
    public $id;
    public $name;
    public $date;
    public $city;
    public $arena;
    public $branches;

    public function __construct($id, $name, $date, $city, $arena, $branches)
    {
        $this->id = $id;
        $this->date = $date;
        $this->name = $name;
        $this->city = $city;
        $this->arena = $arena;
        $this->branches = $branches;
    }
}