<?php
class Branch
{
    public $id;
    public $name;
    public $contestants;
    public $sortedContestants;

    public function __construct($id, $name, $contestants)
    {
        $this->id = $id;
        $this->name = $name;
        $this->contestants = $contestants;
        $this->sortedContestants = $this->sortContestants();
    }

    public function sortContestants()
    {
        $contestantList = [];

        foreach ($this->contestants as $contestant) {
            $contestantList[] = $contestant;
        }

        usort($contestantList, array('Contestant', 'cmp'));

        return $contestantList;
    }
}