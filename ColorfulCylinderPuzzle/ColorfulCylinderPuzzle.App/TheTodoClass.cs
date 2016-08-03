namespace ColorfulCylinderPuzzle.App
{
    /// <summary>
    /// THE MIGHTY CLASS OF TO DOES!!1 (yes its late, and I have to go home finally...)
    /// </summary>
    public class TheTodoClass
    {
        //TODO: behold! here below lies the mighty list of major and minor todos for the whole project! :P
        /*
         * ROADMAP:
         * - Add two actions (or separate them into 4? not sure): GenerateLearningAndTestSets and LoadLearningAndTestSets
         *   Those need to generate pretty big learning and testing sets. The idea is to start with solved puzzle, and then make "smart" moves.
         *   After each move we record the position and mirror move that reverse the position, as the right move to make.
         *   The "smart" moves are those that:
         *   -- do not go back to the same position (within lets say 10 moves or so... OR even the whole history of positions maybe?)
         *   -- are there any more "smart" moves characteristics? maybe not, it's a quite simple puzzle after all (even though hard to solve for a human! :P)
         * IMPROVEMENTS:
         * - Move ClearPuzzle action closer to puzzle panel (and make it smaller)
         * - Add SetPuzzleInSpecificPosition action (probably need another window with color dropdowns or sth like that)
         * - Change log from text to objects (text in textBox can stay, just log more info into separate List of log events or sth)
         * - Add some diagnostics based on log messages like performed actions count, etc.
         * - Add StartRecordActions, StopRecordActions, and Go button which will allow to record set of action and repeat it easily :)
         */
    }
}
