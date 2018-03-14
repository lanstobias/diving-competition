<?php
  class ViewResultController
  {
    public function home()
    {
        if (isset($_POST["contestSelect"])) {
            $selectedContest = $_POST["contestSelect"];
        } else {
            $selectedContest = 0;
        }
        $contests = $this->getContestList();

        require_once('views/pages/view_result.php');
    }

    private function getContestList()
    {
        $database = new Database();

        $query = "SELECT id, name, city, startDate, arena FROM contest;";
        $fetchedContests = $database->getData($query);

        $contests = [];

        foreach ($fetchedContests as $row) {
            $id = $row["id"];
            $name = $row["name"];
            $city = $row["city"];
            $startDate = $row["startDate"];
            $arena = $row["arena"];
            $branches = $this->getBranches($id);

            $contest = new Contest($id, $name, $startDate, $city, $arena, $branches);
            array_push($contests, $contest);
        }

        return $contests;
    }

    private function getContest($id)
    {
        $database = new Database();

        $query = "SELECT id, name, city, startDate, arena FROM contest WHERE id=".$id.";";
        $contests = $database->getData($query);

        $id = $contests[0]["id"];
        $name = $contests[0]["name"];
        $city = $contests[0]["city"];
        $startDate = $contests[0]["startDate"];
        $arena = $contests[0]["arena"];
        $branches = $this->getBranches($id);

        return new Contest($id, $name, $startDate, $city, $arena, $branches);
    }

    private function getBranches($contestID)
    {
        $database = new Database();

        $query = "SELECT id, name FROM branch WHERE contestID=".$contestID.";";
        $fetchedBranches = $database->getData($query);

        $branches = [];

        foreach ($fetchedBranches as $row) {
          $id = $row["id"];
          $name = $row["name"];
          $contestants = $this->getContestants($id);
          
          $branch = new Branch($id, $name, $contestants);
          $branches[] = $branch;
        }

        return $branches;
    }

    private function getContestants($branchID)
    {
        $database = new Database();

        $query = "SELECT contestant.id, personID, person.firstName, person.lastName ";
        $query .= "FROM `contestant` INNER JOIN `branch_contestant` ";
        $query .= "ON contestant.id = branch_contestant.contestantID ";
        $query .= "INNER JOIN `person` ON contestant.personID= person.id ";
        $query .= "WHERE branch_contestant.branchID =".$branchID.";";
        $fetchedContestants = $database->getData($query);

        $contestants = [];

        foreach ($fetchedContestants as $row) {
          $id = $row["id"];
          $firstName = $row["firstName"];
          $lastName = $row["lastName"];
          $dives = $this->getDives($id);
          
          $contestant = new Contestant($id, $firstName, $lastName, $dives);
          $contestants[] = $contestant;
        }

        return $contestants;
    }

    private function getDives($contestantID)
    {
        $database = new Database();

        $query = "SELECT id, code, multiplier, name, finalScore ";
        $query .= "FROM `dive` ";
        $query .= "WHERE contestantID = ".$contestantID.";";
        $fetchedDives = $database->getData($query);

        $dives = [];

        foreach ($fetchedDives as $row) {
          $id = $row["id"];
          $code = $row["code"];
          $multiplier = $row["multiplier"];
          $name = $row["name"];
          $finalScore = $row["finalScore"];
          $points = $this->getPoints($id);
          
          $dive = new Dive($id, $code, $multiplier, $name, $points, $finalScore);
          $dives[] = $dive;
        }

        return $dives;
    }

    private function getPoints($diveID)
    {
        $database = new Database();

        $query = "SELECT id, point, judgeID ";
        $query .= "FROM `point` ";
        $query .= "WHERE diveID = ".$diveID.";";
        $fetchedPoints = $database->getData($query);

        $points = [];

        foreach ($fetchedPoints as $row) {
          $id = $row["id"];
          $point = $row["point"];
          $judgeID = $row["judgeID"];
          
          $point = new Point($id, $point, $judgeID);
          $points[] = $point;
        }

        return $points;
    }
  }