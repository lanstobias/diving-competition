<?php $contest = $contests[$selectedContest]; ?>
<div class="row justify-content-center">
    <div class="col-lg-8">

        <form style="margin-bottom: 50px" method="POST">
            <div class="form-group">
                <label for="exampleFormControlSelect1">Välj tävling att visa</label>
                <select class="form-control" name="contestSelect">
                <?php $i = 0; ?>
                <?php 
                    foreach ($contests as $optionContest) {
                        echo "<option value='".$i++."'";
                        if ($contest->id == $optionContest->id) {
                            echo "selected";
                        }
                        echo ">".utf8_encode($optionContest->name)."</option>";
                    } 
                ?>
                </select>
            </div>
            <button type="submit" class="btn btn-light" onclick="location.href='?controller=view_result&action=home'">Visa resultat</button>
        </form>

    <?php if (isset($_POST["contestSelect"])) { ?>
        <h2><?php print utf8_encode($contest->name); ?></h2>
        <p>
            <?php echo utf8_encode($contest->city); ?><br>
            <?php echo $contest->date; ?><br>
            <?php echo utf8_encode($contest->arena); ?>
        </p>

        <!-- Table -->
        <table class="table table-hover table-sm">

            <?php foreach ($contest->branches as $branch) { ?>
                <thead class="thead-light">
                    <tr>
                        <th scope="row"><?php echo utf8_encode($branch->name); ?></th>
                        <th scope="row"></th>
                        <th scope="row"></th>
                        <th scope="row"></th>
                        <th scope="row"></th>
                        <th scope="row"></th>
                        <th scope="row"></th>
                    </tr>
                </thead>
                <thead class="thead table-sm" style="background-color:#f6f7f8; font-size:12px;">
                    <tr>
                        <th># &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Namn</th>
                        <th>Hoppkod</th>
                        <th>DD</th>
                        <th>Total</th>
                        <th>Points</th>
                        <th>Score</th>
                        <th scope="col"></th>
                    </tr>
                </thead>

                <!-- Contestant -->
                <?php $place = 1; ?>
                <?php foreach ($branch->sortedContestants as $contestant) { ?>
                    <thead class="thead table-sm">
                        <tr>
                            <th><?php print($place++." &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;".utf8_encode($contestant->firstName." ".$contestant->lastName)); ?></th>
                            <th></th>
                            <th></th>
                            <th></th>
                            <th></th>
                            <th></th>
                            <th></th>
                        </tr>
                    </thead>

                    <!-- Dives -->
                    <?php $sum = 0; ?>
                    <?php foreach ($contestant->dives as $dive) {
                        $sum += ($dive->finalScore * $dive->multiplier);
                    ?>
                    <tbody>
                        <tr>
                            <th scope="col"></th>
                            <td><?php echo $dive->code; ?></td>
                            <td><?php echo $dive->multiplier; ?></td>
                            <td><?php echo $dive->finalScore; ?></td>
                            <td><?php echo $dive->finalScore * $dive->multiplier; ?></td>
                            <td><?php echo $sum; ?></td>
                        </tr>
                    </tbody>
                    <?php } ?>

                <?php } ?>

            <?php } ?>
        </table>
        <?php } ?>
    </div>
</div>