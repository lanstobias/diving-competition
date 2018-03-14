<?php
class Contestant
{
    public $id;
    public $firstName;
    public $lastName;
    public $dives;
    public $sum;
    public $point;

    public function __construct($id, $firstName, $lastName, $dives)
    {
        $this->id = $id;
        $this->firstName = $firstName;
        $this->lastName = $lastName;
        $this->dives = $dives;
        $this->sum = $this->generateSum();
    }

    public static function cmp($contestant_a, $contestant_b)
    {
        return ($contestant_a->sum < $contestant_b->sum);
    }

    public function generateSum()
    {
        $sum = 0;
        foreach ($this->dives as $dive) {
            $sum += $dive->finalScore * $dive->multiplier;
        }

        return $sum;
    }
}