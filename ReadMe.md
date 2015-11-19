# MasterLock Combo Cracker (script)
Uses Samy Kamkar's algorithm to make a set of possible combinations for MasterLock's padlocks. 
3 values are needed in order to predict the combination, and they are:
 - 1) First locked position
 -    Set the dial to 0.
 -    Apply pressure upward on the shackle, like you are opening it.
 -    Rotate the dial counter-clockwise (towards 5) until the dial is locked and will not turn.
 -    You will be unable to turn around a number, but this value do not matter yet.
 -    Skip these number by releasing pressure on the shackle, turn the dial enough to get past where you were stuck.
 -    Again, apply pressure upward on the shackle, as if you are opening it, and continue to turn the dial left.
 -    If you are stopped on a whole number, record that value.
 -    If you are stopped between two halfs (3.5 - 4.5) - use the number between (4).
 -    (Remember, this value shouldn't be the 1st locked position value, since we skipped it, it should be the 2nd)
 
 - 2) Second Locked Position
 -    Continue from where you left off above, from the recorded locked position.
 -    Continue putting upward pressure and turning the dial until you are in the next locked position.
 -    If you are stopped on a whole number, record that value.
 -    If you are stopped between two halfs (6.5 - 7.5) - use the number between (7).
 -    (Remember, this value shouldn't be the 2nd locked position value, since we already recorded that, it should be the 3rd)
 -    Also, the 2 recorded values should be before you pass 11, if not, restart the process and carefully record the positions.
    
 - 3) Resistance Location
 -    Apply less pressure to the shackle as you did before (about half), so the dial can turn and not get locked in place.
 -    This time, rotate the dial to the right, until you feel resistance.
 -    Note the value (with 1 decimal place) that resistance begins to happen. ie (14.5 or 15.0)
 -    Rotate the dial several more times to ensure that the recorded value is indeed the resistance location.
     
 - 4) Finding the 'Correct' 3rd digit
 -    Set the Dial to the first posibility for the '3rd Digit'
 -    Apply full pressure upward on the shackle, as if you are opening it.
 -    Turn the dial and note how much give there is (whether it be half a number or 2 full numbers worth).
 -    Loosen the shackle and set the dial to the next possibility for the '3rd Digit'
 -    Apply full pressure upward again, and note the ammount of give for the 2nd option of the 3rd digit.
 -    Whichever option has a greater give, use that option (1 or 2)
