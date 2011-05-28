﻿using System;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FluentAssertions.Specs
{
    [TestClass]
    public class StringAssertionSpecs
    {
        #region Equal

        [TestMethod]
        public void When_both_values_are_the_same_it_should_not_throw()
        {
            //-------------------------------------------------------------------------------------------------------------------
            // Act / Assert
            //-------------------------------------------------------------------------------------------------------------------
            "ABC".Should().Be("ABC");
        }

        [TestMethod]
        public void When_both_subject_and_expected_are_null_it_should_succeed()
        {
            //-------------------------------------------------------------------------------------------------------------------
            // Arrange
            //-------------------------------------------------------------------------------------------------------------------
            string actualString = null;
            string expectedString = null;

            //-------------------------------------------------------------------------------------------------------------------
            // Act
            //-------------------------------------------------------------------------------------------------------------------
            Action act = () => actualString.Should().Be(expectedString);

            //-------------------------------------------------------------------------------------------------------------------
            // Assert
            //-------------------------------------------------------------------------------------------------------------------
            act.ShouldNotThrow();
        }

        [TestMethod]
        public void When_two_strings_differ_unexpectingly_it_should_throw()
        {
            //-----------------------------------------------------------------------------------------------------------
            // Act
            //-----------------------------------------------------------------------------------------------------------
            Action act = () => "ADC".Should().Be("ABC", "because we {0}", "do");

            //-----------------------------------------------------------------------------------------------------------
            // Assert
            //-----------------------------------------------------------------------------------------------------------
            act.ShouldThrow<AssertFailedException>().WithMessage(
                "Expected string to be \"ABC\" because we do, but \"ADC\" differs near \"DC\" (index 1).");
        }

        [TestMethod]
        public void When_the_expected_string_is_shorter_than_the_actual_string_it_should_throw()
        {
            //-----------------------------------------------------------------------------------------------------------
            // Act
            //-----------------------------------------------------------------------------------------------------------
            Action act = () => "ABC".Should().Be("AB");

            //-----------------------------------------------------------------------------------------------------------
            // Assert
            //-----------------------------------------------------------------------------------------------------------
            act.ShouldThrow<AssertFailedException>().WithMessage(
                "Expected string to be \"AB\", but \"ABC\" is too long.");
        }

        [TestMethod]
        public void When_the_expected_string_is_longer_than_the_actual_string_it_should_throw()
        {
            //-----------------------------------------------------------------------------------------------------------
            // Act
            //-----------------------------------------------------------------------------------------------------------
            Action act = () => "AB".Should().Be("ABC");

            //-----------------------------------------------------------------------------------------------------------
            // Assert
            //-----------------------------------------------------------------------------------------------------------
            act.ShouldThrow<AssertFailedException>().WithMessage(
                "Expected string to be \"ABC\", but \"AB\" is too short.");
        }

        [TestMethod]
        public void When_string_is_expected_to_equal_null_it_should_throw()
        {
            //-----------------------------------------------------------------------------------------------------------
            // Act
            //-----------------------------------------------------------------------------------------------------------
            Action act = () => "AB".Should().Be(null);

            //-----------------------------------------------------------------------------------------------------------
            // Assert
            //-----------------------------------------------------------------------------------------------------------
            act.ShouldThrow<AssertFailedException>().WithMessage(
                "Expected string to be <null>, but found \"AB\".");
        }

        [TestMethod]
        public void When_string_is_expected_to_be_null_it_should_throw()
        {
            //-----------------------------------------------------------------------------------------------------------
            // Act
            //-----------------------------------------------------------------------------------------------------------
            Action act = () => "AB".Should().BeNull("we like {0}", "null");

            //-----------------------------------------------------------------------------------------------------------
            // Assert
            //-----------------------------------------------------------------------------------------------------------
            act.ShouldThrow<AssertFailedException>().WithMessage(
                "Expected string to be <null> because we like null, but found \"AB\".");
        }

        [TestMethod]
        public void When_the_expected_string_is_null_then_it_should_throw()
        {
            //-----------------------------------------------------------------------------------------------------------
            // Act
            //-----------------------------------------------------------------------------------------------------------
            string someString = null;
            Action act = () => someString.Should().Be("ABC");

            //-----------------------------------------------------------------------------------------------------------
            // Assert
            //-----------------------------------------------------------------------------------------------------------
            act.ShouldThrow<AssertFailedException>().WithMessage(
                "Expected string to be \"ABC\", but found <null>.");
        }

        [TestMethod]
        public void When_the_expected_string_is_the_same_but_with_trailing_spaces_it_should_throw_with_clear_error_message()
        {
            //-----------------------------------------------------------------------------------------------------------
            // Act
            //-----------------------------------------------------------------------------------------------------------
            Action act = () => "ABC".Should().Be("ABC ", "because I say {0}", "so");

            //-----------------------------------------------------------------------------------------------------------
            // Assert
            //-----------------------------------------------------------------------------------------------------------
            act.ShouldThrow<AssertFailedException>().WithMessage(
                "Expected string to be \"ABC \" because I say so, but it misses some extra whitespace at the end.");
        }

        [TestMethod]
        public void When_the_actual_string_is_the_same_as_the_expected_but_with_trailing_spaces_it_should_throw_with_clear_error_message()
        {
            //-----------------------------------------------------------------------------------------------------------
            // Act
            //-----------------------------------------------------------------------------------------------------------
            Action act = () => "ABC ".Should().Be("ABC", "because I say {0}", "so");

            //-----------------------------------------------------------------------------------------------------------
            // Assert
            //-----------------------------------------------------------------------------------------------------------
            act.ShouldThrow<AssertFailedException>().WithMessage(
                "Expected string to be \"ABC\" because I say so, but it has unexpected whitespace at the end.");
        }

        [TestMethod]
        public void When_two_strings_differ_and_one_of_them_is_long_it_should_display_both_strings_on_separate_line()
        {
            //-----------------------------------------------------------------------------------------------------------
            // Act
            //-----------------------------------------------------------------------------------------------------------
            Action act = () => "1234567890".Should().Be("0987654321");

            //-----------------------------------------------------------------------------------------------------------
            // Assert
            //-----------------------------------------------------------------------------------------------------------
            act.ShouldThrow<AssertFailedException>().WithMessage(
                "Expected string to be \r\n\"0987654321\", but \r\n\"1234567890\" differs near \"123\" (index 0).");
        }
        
        [TestMethod]
        public void When_two_strings_differ_and_one_of_them_is_multiline_it_should_display_both_strings_on_separate_line()
        {
            //-----------------------------------------------------------------------------------------------------------
            // Actt
            //-----------------------------------------------------------------------------------------------------------
            Action act = () => "A\r\nB".Should().Be("A\r\nC");

            //-----------------------------------------------------------------------------------------------------------
            // Assert
            //-----------------------------------------------------------------------------------------------------------
            act.ShouldThrow<AssertFailedException>().WithMessage(
                "Expected string to be \r\n\"A\\r\\nC\", but \r\n\"A\\r\\nB\" differs near \"B\" (index 3).");
        }

        #endregion

        #region Not Equal

        [TestMethod]
        public void When_different_strings_are_expected_to_differ_it_should_not_throw()
        {
            "ABC".Should().NotBe("DEF");
        }

        [TestMethod]
        public void When_equal_strings_are_expected_to_differ_it_should_throw()
        {
            //-----------------------------------------------------------------------------------------------------------
            // Act
            //-----------------------------------------------------------------------------------------------------------
            Action act = () => "ABC".Should().NotBe("ABC", "because we don't like {0}", "ABC");

            //-----------------------------------------------------------------------------------------------------------
            // Assert
            //-----------------------------------------------------------------------------------------------------------
            act.ShouldThrow<AssertFailedException>().WithMessage(
                "Expected string not to be \"ABC\" because we don't like ABC.");
        }

        [TestMethod]
        public void When_non_empty_string_is_not_equal_to_empty_it_should_not_throw()
        {
            //-----------------------------------------------------------------------------------------------------------
            // Act
            //-----------------------------------------------------------------------------------------------------------
            "ABC".Should().NotBe("");
        }

        [TestMethod]
        public void When_empty_string_is_not_supposed_to_be_equal_to_empty_it_should_throw()
        {
            //-----------------------------------------------------------------------------------------------------------
            // Act
            //-----------------------------------------------------------------------------------------------------------
            Action act = () => "".Should().NotBe("");

            //-----------------------------------------------------------------------------------------------------------
            // Assert
            //-----------------------------------------------------------------------------------------------------------
            act.ShouldThrow<AssertFailedException>().WithMessage(
                "Expected string not to be \"\".");
        }

        [TestMethod]
        public void When_valid_string_is_not_supposed_to_be_null_it_should_not_throw()
        {
            //-----------------------------------------------------------------------------------------------------------
            // Act
            //-----------------------------------------------------------------------------------------------------------
            "ABC".Should().NotBe(null);
        }

        [TestMethod]
        public void When_null_string_is_not_supposed_to_be_equal_to_null_it_should_throw()
        {
            //-----------------------------------------------------------------------------------------------------------
            // Act
            //-----------------------------------------------------------------------------------------------------------
            string someString = null;
            Action act = () => someString.Should().NotBe(null);

            //-----------------------------------------------------------------------------------------------------------
            // Assert
            //-----------------------------------------------------------------------------------------------------------
            act.ShouldThrow<AssertFailedException>().WithMessage(
                "Expected string not to be <null>.");
        }

        [TestMethod]
        public void When_null_string_is_not_supposed_to_be_null_it_should_throw()
        {
            //-----------------------------------------------------------------------------------------------------------
            // Act
            //-----------------------------------------------------------------------------------------------------------
            string someString = null;
            Action act = () => someString.Should().NotBeNull("we don't like {0}", "null");

            //-----------------------------------------------------------------------------------------------------------
            // Assert
            //-----------------------------------------------------------------------------------------------------------
            act.ShouldThrow<AssertFailedException>().WithMessage(
                "Expected string not to be <null> because we don't like null.");
        }

        #endregion

        #region Start With

        [TestMethod]
        public void When_asserting_string_starts_with_the_same_value_it_should_not_throw()
        {
            "ABC".Should().StartWith("AB");
        }

        [TestMethod]
        public void When_string_does_not_start_with_expected_phrase_it_should_throw()
        {
            //-----------------------------------------------------------------------------------------------------------
            // Act
            //-----------------------------------------------------------------------------------------------------------
            Action act = () => "ABC".Should().StartWith("BC", "it should {0}", "start");

            //-----------------------------------------------------------------------------------------------------------
            // Assert
            //-----------------------------------------------------------------------------------------------------------
            act.ShouldThrow<AssertFailedException>().WithMessage(
                "Expected string \"ABC\" to start with \"BC\" because it should start.");
        }

        [TestMethod]
        public void When_string_start_is_compared_with_null_it_should_throw()
        {
            //-----------------------------------------------------------------------------------------------------------
            // Act
            //-----------------------------------------------------------------------------------------------------------
            Action act = () => "ABC".Should().StartWith(null);

            //-----------------------------------------------------------------------------------------------------------
            // Assert
            //-----------------------------------------------------------------------------------------------------------
            act.ShouldThrow<NullReferenceException>().WithMessage(
                "Cannot compare start of string with <null>.");
        }

        [TestMethod]
        public void When_string_start_is_compared_with_empty_string_it_should_throw()
        {
            //-----------------------------------------------------------------------------------------------------------
            // Act
            //-----------------------------------------------------------------------------------------------------------
            Action act = () => "ABC".Should().StartWith("");

            //-----------------------------------------------------------------------------------------------------------
            // Assert
            //-----------------------------------------------------------------------------------------------------------
            act.ShouldThrow<ArgumentException>().WithMessage(
                "Cannot compare start of string with empty string.");
        }

        [TestMethod]
        public void When_string_start_is_compared_and_actual_value_is_null_then_it_should_throw()
        {
            //-----------------------------------------------------------------------------------------------------------
            // Act
            //-----------------------------------------------------------------------------------------------------------
            string someString = null;
            Action act = () => someString.Should().StartWith("ABC");

            //-----------------------------------------------------------------------------------------------------------
            // Assert
            //-----------------------------------------------------------------------------------------------------------
            act.ShouldThrow<AssertFailedException>().WithMessage(
                "Expected string <null> to start with \"ABC\".");
        }

        #endregion

        #region End With

        [TestMethod]
        public void When_asserting_string_ends_with_the_same_value_it_should_not_throw()
        {
            "ABC".Should().EndWith("BC");
        }

        [TestMethod]
        public void When_string_does_not_end_with_expected_phrase_it_should_throw()
        {
            //-----------------------------------------------------------------------------------------------------------
            // Act
            //-----------------------------------------------------------------------------------------------------------
            Action act = () => "ABC".Should().EndWith("AB", "it should");

            //-----------------------------------------------------------------------------------------------------------
            // Assert
            //-----------------------------------------------------------------------------------------------------------
            act.ShouldThrow<AssertFailedException>().WithMessage(
                "Expected string \"ABC\" to end with \"AB\" because it should.");
        }

        [TestMethod]
        public void When_string_ending_is_compared_with_null_it_should_throw()
        {
            //-----------------------------------------------------------------------------------------------------------
            // Act
            //-----------------------------------------------------------------------------------------------------------
            Action act = () => "ABC".Should().EndWith(null);

            //-----------------------------------------------------------------------------------------------------------
            // Assert
            //-----------------------------------------------------------------------------------------------------------
            act.ShouldThrow<NullReferenceException>().WithMessage(
                "Cannot compare string end with <null>.");
        }

        [TestMethod]
        public void When_string_ending_is_compared_with_empty_string_it_should_throw()
        {
            //-----------------------------------------------------------------------------------------------------------
            // Act
            //-----------------------------------------------------------------------------------------------------------
            Action act = () => "ABC".Should().EndWith("");

            //-----------------------------------------------------------------------------------------------------------
            // Assert
            //-----------------------------------------------------------------------------------------------------------
            act.ShouldThrow<ArgumentException>().WithMessage(
                "Cannot compare string end with empty string.");
        }

        [TestMethod]
        public void When_string_ending_is_compared_and_actual_value_is_null_then_it_should_throw()
        {
            //-----------------------------------------------------------------------------------------------------------
            // Act
            //-----------------------------------------------------------------------------------------------------------
            string someString = null;
            Action act = () => someString.Should().EndWith("ABC");

            //-----------------------------------------------------------------------------------------------------------
            // Assert
            //-----------------------------------------------------------------------------------------------------------
            act.ShouldThrow<AssertFailedException>().WithMessage(
                "Expected string <null> to end with \"ABC\".");
        }

        #endregion

        #region Start With Equivalent

        [TestMethod]
        public void When_start_of_string_differs_by_case_only_it_should_not_throw()
        {
            "ABC".Should().StartWithEquivalent("Ab");
        }

        [TestMethod]
        public void When_start_of_string_does_not_meet_equivalent_it_should_throw()
        {
            //-----------------------------------------------------------------------------------------------------------
            // Act
            //-----------------------------------------------------------------------------------------------------------
            Action act = () => "ABC".Should().StartWithEquivalent("bc", "because it should start");

            //-----------------------------------------------------------------------------------------------------------
            // Assert
            //-----------------------------------------------------------------------------------------------------------
            act.ShouldThrow<AssertFailedException>().WithMessage(
                "Expected string \"ABC\" to start with equivalent of \"bc\" because it should start.");
        }

        [TestMethod]
        public void When_start_of_string_is_compared_with_equivalent_of_null_it_should_throw()
        {
            //-----------------------------------------------------------------------------------------------------------
            // Act
            //-----------------------------------------------------------------------------------------------------------
            Action act = () => "ABC".Should().StartWithEquivalent(null);

            //-----------------------------------------------------------------------------------------------------------
            // Assert
            //-----------------------------------------------------------------------------------------------------------
            act.ShouldThrow<NullReferenceException>().WithMessage(
                "Cannot compare string start equivalence with <null>.");
        }

        [TestMethod]
        public void When_start_of_string_is_compared_with_equivalent_of_empty_string_it_should_throw()
        {
            //-----------------------------------------------------------------------------------------------------------
            // Act
            //-----------------------------------------------------------------------------------------------------------
            Action act = () => "ABC".Should().StartWithEquivalent("");

            //-----------------------------------------------------------------------------------------------------------
            // Assert
            //-----------------------------------------------------------------------------------------------------------
            act.ShouldThrow<ArgumentException>().WithMessage(
                "Cannot compare string start equivalence with empty string.");
        }

        [TestMethod]
        public void When_string_start_is_compared_with_equivalent_and_actual_value_is_null_then_it_should_throw()
        {
            //-----------------------------------------------------------------------------------------------------------
            // Act
            //-----------------------------------------------------------------------------------------------------------
            string someString = null;
            Action act = () => someString.Should().StartWithEquivalent("AbC");

            //-----------------------------------------------------------------------------------------------------------
            // Assert
            //-----------------------------------------------------------------------------------------------------------
            act.ShouldThrow<AssertFailedException>().WithMessage(
                "Expected string <null> to start with equivalent of \"AbC\".");
        }

        #endregion

        #region End With Equivalent

        [TestMethod]
        public void When_end_of_string_differs_by_case_only_it_should_not_throw()
        {
            "ABC".Should().EndWithEquivalent("bC");
        }

        [TestMethod]
        public void When_end_of_string_does_not_meet_equivalent_it_should_throw()
        {
            //-----------------------------------------------------------------------------------------------------------
            // Act
            //-----------------------------------------------------------------------------------------------------------
            Action act = () => "ABC".Should().EndWithEquivalent("ab", "because it should end");

            //-----------------------------------------------------------------------------------------------------------
            // Assert
            //-----------------------------------------------------------------------------------------------------------
            act.ShouldThrow<AssertFailedException>().WithMessage(
                "Expected string \"ABC\" to end with equivalent of \"ab\" because it should end.");
        }

        [TestMethod]
        public void When_end_of_string_is_compared_with_equivalent_of_null_it_should_throw()
        {
            //-----------------------------------------------------------------------------------------------------------
            // Act
            //-----------------------------------------------------------------------------------------------------------
            Action act = () => "ABC".Should().EndWithEquivalent(null);

            //-----------------------------------------------------------------------------------------------------------
            // Assert
            //-----------------------------------------------------------------------------------------------------------
            act.ShouldThrow<NullReferenceException>().WithMessage(
                "Cannot compare string end equivalence with <null>.");
        }

        [TestMethod]
        public void When_end_of_string_is_compared_with_equivalent_of_empty_string_it_should_throw()
        {
            //-----------------------------------------------------------------------------------------------------------
            // Act
            //-----------------------------------------------------------------------------------------------------------
            Action act = () => "ABC".Should().EndWithEquivalent("");

            //-----------------------------------------------------------------------------------------------------------
            // Assert
            //-----------------------------------------------------------------------------------------------------------
            act.ShouldThrow<ArgumentException>().WithMessage(
                "Cannot compare string end equivalence with empty string.");
        }

        [TestMethod]
        public void When_string_ending_is_compared_with_equivalent_and_actual_value_is_null_then_it_should_throw()
        {
            //-----------------------------------------------------------------------------------------------------------
            // Act
            //-----------------------------------------------------------------------------------------------------------
            string someString = null;
            Action act = () => someString.Should().EndWithEquivalent("abC");

            //-----------------------------------------------------------------------------------------------------------
            // Assert
            //-----------------------------------------------------------------------------------------------------------
            act.ShouldThrow<AssertFailedException>().WithMessage(
                "Expected string <null> to end with equivalent of \"abC\".");
        }

        #endregion

        #region Contain

        [TestMethod]
        public void When_string_contains_the_expected_string_it_should_not_throw()
        {
            "ABCDEF".Should().Contain("BCD");
        }

        [TestMethod]
        public void When_string_does_not_contain_an_expected_string_it_should_throw()
        {
            //-----------------------------------------------------------------------------------------------------------
            // Act
            //-----------------------------------------------------------------------------------------------------------
            Action act = () => "ABCDEF".Should().Contain("XYZ", "that is {0}", "required");

            //-----------------------------------------------------------------------------------------------------------
            // Assert
            //-----------------------------------------------------------------------------------------------------------
            act.ShouldThrow<AssertFailedException>().WithMessage(
                "Expected string \"ABCDEF\" to contain \"XYZ\" because that is required.");
        }

        [TestMethod]
        public void When_containment_is_asserted_against_null_it_should_throw()
        {
            //-----------------------------------------------------------------------------------------------------------
            // Act
            //-----------------------------------------------------------------------------------------------------------
            Action act = () => "a".Should().Contain(null);

            //-----------------------------------------------------------------------------------------------------------
            // Assert
            //-----------------------------------------------------------------------------------------------------------
            act
                .ShouldThrow<ArgumentException>()
                .WithMessage("Cannot assert string containment against <null>.");
        }
        
        [TestMethod]
        public void When_containment_is_asserted_against_an_empty_string_it_should_throw()
        {
            //-----------------------------------------------------------------------------------------------------------
            // Act
            //-----------------------------------------------------------------------------------------------------------
            Action act = () => "a".Should().Contain("");

            //-----------------------------------------------------------------------------------------------------------
            // Assert
            //-----------------------------------------------------------------------------------------------------------
            act
                .ShouldThrow<ArgumentException>()
                .WithMessage("Cannot assert string containment against an empty string.");
        }

        [TestMethod]
        public void When_string_containment_is_asserted_and_actual_value_is_null_then_it_should_throw()
        {
            //-----------------------------------------------------------------------------------------------------------
            // Act
            //-----------------------------------------------------------------------------------------------------------
            string someString = null;
            Action act = () => someString.Should().Contain("XYZ", "that is {0}", "required");

            //-----------------------------------------------------------------------------------------------------------
            // Assert
            //-----------------------------------------------------------------------------------------------------------
            act.ShouldThrow<AssertFailedException>().WithMessage(
                 "Expected string <null> to contain \"XYZ\" because that is required.");
        }

        #endregion

        #region Be Equivalent To

        [TestMethod]
        public void When_strings_are_the_same_while_ignoring_case_it_should_not_throw()
        {
            "ABC".Should().BeEquivalentTo("abc");
        }

        [TestMethod]
        public void When_strings_differ_other_than_by_case_it_should_throw()
        {
            //-----------------------------------------------------------------------------------------------------------
            // Act
            //-----------------------------------------------------------------------------------------------------------
            Action act = () => "ADC".Should().BeEquivalentTo("abc", "we will test {0} + {1}", 1, 2);

            //-----------------------------------------------------------------------------------------------------------
            // Assert
            //-----------------------------------------------------------------------------------------------------------
            act.ShouldThrow<AssertFailedException>().WithMessage(
                "Expected string to be equivalent to \"abc\" because we will test 1 + 2, but \"ADC\" differs near \"DC\" (index 1).");
        }

        [TestMethod]
        public void When_non_null_string_is_expected_to_be_equivalent_to_null_it_should_throw()
        {
            //-----------------------------------------------------------------------------------------------------------
            // Act
            //-----------------------------------------------------------------------------------------------------------
            Action act = () => "ABCDEF".Should().BeEquivalentTo(null);

            //-----------------------------------------------------------------------------------------------------------
            // Assert
            //-----------------------------------------------------------------------------------------------------------
            act.ShouldThrow<AssertFailedException>().WithMessage(
                "Expected string to be equivalent to <null>, but found \"ABCDEF\".");
        }

        [TestMethod]
        public void When_non_empty_string_is_expected_to_be_equivalent_to_empty_it_should_throw()
        {
            //-----------------------------------------------------------------------------------------------------------
            // Act
            //-----------------------------------------------------------------------------------------------------------
            Action act = () => "ABC".Should().BeEquivalentTo("");

            //-----------------------------------------------------------------------------------------------------------
            // Assert
            //-----------------------------------------------------------------------------------------------------------
            act.ShouldThrow<AssertFailedException>().WithMessage(
                "Expected string to be equivalent to \"\", but \"ABC\" is too long.");
        }

        [TestMethod]
        public void When_string_is_equivalent_but_too_short_it_should_throw()
        {
            //-----------------------------------------------------------------------------------------------------------
            // Act
            //-----------------------------------------------------------------------------------------------------------
            Action act = () => "AB".Should().BeEquivalentTo("ABCD");

            //-----------------------------------------------------------------------------------------------------------
            // Assert
            //-----------------------------------------------------------------------------------------------------------
            act.ShouldThrow<AssertFailedException>().WithMessage(
                "Expected string to be equivalent to \"ABCD\", but \"AB\" is too short.");
        }

        [TestMethod]
        public void When_string_equivalence_is_asserted_and_actual_value_is_null_then_it_should_throw()
        {
            //-----------------------------------------------------------------------------------------------------------
            // Act
            //-----------------------------------------------------------------------------------------------------------
            string someString = null;
            Action act = () => someString.Should().BeEquivalentTo("abc", "we will test {0} + {1}", 1, 2);

            //-----------------------------------------------------------------------------------------------------------
            // Assert
            //-----------------------------------------------------------------------------------------------------------
            act.ShouldThrow<AssertFailedException>().WithMessage(
                  "Expected string to be equivalent to \"abc\" because we will test 1 + 2, but found <null>.");
        }

        [TestMethod]
        public void When_the_expected_string_is_equivalent_to_the_actual_string_but_with_trailing_spaces_it_should_throw_with_clear_error_message()
        {
            //-----------------------------------------------------------------------------------------------------------
            // Act
            //-----------------------------------------------------------------------------------------------------------
            Action act = () => "ABC".Should().BeEquivalentTo("abc ", "because I say {0}", "so");

            //-----------------------------------------------------------------------------------------------------------
            // Assert
            //-----------------------------------------------------------------------------------------------------------
            act.ShouldThrow<AssertFailedException>().WithMessage(
                "Expected string to be equivalent to \"abc \" because I say so, but it misses some extra whitespace at the end.");
        }

        [TestMethod]
        public void When_the_actual_string_equivalent_to_the_expected_but_with_trailing_spaces_it_should_throw_with_clear_error_message()
        {
            //-----------------------------------------------------------------------------------------------------------
            // Act
            //-----------------------------------------------------------------------------------------------------------
            Action act = () => "ABC ".Should().BeEquivalentTo("abc", "because I say {0}", "so");

            //-----------------------------------------------------------------------------------------------------------
            // Assert
            //-----------------------------------------------------------------------------------------------------------
            act.ShouldThrow<AssertFailedException>().WithMessage(
                "Expected string to be equivalent to \"abc\" because I say so, but it has unexpected whitespace at the end.");
        }

        #endregion

        #region Not Contain

        [TestMethod]
        public void When_string_does_not_contain_the_unexpected_string_it_should_succeed()
        {
            //-----------------------------------------------------------------------------------------------------------
            // Act
            //-----------------------------------------------------------------------------------------------------------
            Action act = () => "a".Should().NotContain("A");
 
            //-----------------------------------------------------------------------------------------------------------
            // Assert
            //-----------------------------------------------------------------------------------------------------------
            act.ShouldNotThrow();
        }

        [TestMethod]
        public void When_string_contains_unexpected_fragment_it_should_throw()
        {
            //-----------------------------------------------------------------------------------------------------------
            // Act
            //-----------------------------------------------------------------------------------------------------------
            Action act = () => "abcd".Should().NotContain("bc", "it was not expected {0}", "today");

            //-----------------------------------------------------------------------------------------------------------
            // Assert
            //-----------------------------------------------------------------------------------------------------------
            act.ShouldThrow<AssertFailedException>()
                .WithMessage("Did not expect string \"abcd\" to contain \"bc\" because it was not expected today.");
        }

        [TestMethod]
        public void When_exclusion_is_asserted_against_null_it_should_throw()
        {
            //-----------------------------------------------------------------------------------------------------------
            // Act
            //-----------------------------------------------------------------------------------------------------------
            Action act = () => "a".Should().NotContain(null);

            //-----------------------------------------------------------------------------------------------------------
            // Assert
            //-----------------------------------------------------------------------------------------------------------
            act
                .ShouldThrow<ArgumentException>()
                .WithMessage("Cannot assert string containment against <null>.");
        }

        [TestMethod]
        public void When_exclusion_is_asserted_against_an_empty_string_it_should_throw()
        {
            //-----------------------------------------------------------------------------------------------------------
            // Act
            //-----------------------------------------------------------------------------------------------------------
            Action act = () => "a".Should().NotContain("");

            //-----------------------------------------------------------------------------------------------------------
            // Assert
            //-----------------------------------------------------------------------------------------------------------
            act
                .ShouldThrow<ArgumentException>()
                .WithMessage("Cannot assert string containment against an empty string.");
        }

        #endregion

        #region Not Contain Equivalent Of

        [TestMethod]
        public void Should_not_contain_equivalent_of_null_or_empty_in_anything_should_fail()
        {
            AssertEx.Throws<AssertFailedException>(() => "a".Should().NotContainEquivalentOf(null))
                .WithMessage("Did not expect string to contain equivalent of <null> but found \"a\"");

            AssertEx.Throws<AssertFailedException>(() => "a".Should().NotContainEquivalentOf(""))
                .WithMessage("Did not expect string to contain equivalent of \"\" but found \"a\"");
        }

        [TestMethod]
        public void Should_not_contain_equivalent_of_should_fail_when_contains()
        {
            AssertEx.Throws<AssertFailedException>(() => "DaBc".Should().NotContainEquivalentOf("ab"))
                .WithMessage("Did not expect string to contain equivalent of \"ab\" but found \"DaBc\"");

            AssertEx.Throws<AssertFailedException>(() => "Hello, world!".Should().NotContainEquivalentOf(", worLD!"))
                .WithMessage("Did not expect string to contain equivalent of \", worLD!\" but found \"Hello, world!\"");
        }

        [TestMethod]
        public void Should_not_contain_equivalent_of_should_pass_when_not_contains()
        {
            "aB".Should().NotContainEquivalentOf("ac");
            "aAa".Should().NotContainEquivalentOf("aa ");
        }
        
        #endregion

        #region Contain Equivalent Of

        [TestMethod]
        public void Should_pass_when_contans_equivalent_of()
        {
            "aa".Should().ContainEquivalentOf("A");
            "aCCa".Should().ContainEquivalentOf("acca");
        }

        [TestMethod]
        public void Should_fail_contain_equivalent_of_when_not_contains()
        {
            AssertEx.Throws<AssertFailedException>(() => "a".Should().ContainEquivalentOf("aa"))
                .WithMessage("Expected string to contain equivalent of \"aa\" but found \"a\"");

            AssertEx.Throws<AssertFailedException>(() => "aaBBcc".Should().ContainEquivalentOf("aBc"))
                .WithMessage("Expected string to contain equivalent of \"aBc\" but found \"aaBBcc\"");
        }

        [TestMethod]
        public void Should_throw_when_null_or_empty_equivalent_is_expected()
        {
            var expectedMessage = "Null and empty strings are considered to be contained in all strings." +
                Environment.NewLine + "Parameter name: expectedValue";

            AssertEx.Throws<ArgumentNullException>(() => "a".Should().ContainEquivalentOf(null)).WithMessage(expectedMessage);
            AssertEx.Throws<ArgumentNullException>(() => "a".Should().ContainEquivalentOf("")).WithMessage(expectedMessage);
        }
        
        #endregion

        #region (Not) Empty

        [TestMethod]
        public void Should_succeed_when_asserting_empty_string_to_be_empty()
        {
            "".Should().BeEmpty();
        }

        [TestMethod]
        [ExpectedException(typeof(AssertFailedException))]
        public void Should_fail_when_asserting_non_empty_string_to_be_empty()
        {
            "ABC".Should().BeEmpty();
        }

        [TestMethod]
        public void Should_fail_with_descriptive_message_when_asserting_non_empty_string_to_be_empty()
        {
            var assertions = "ABC".Should();
            assertions.Invoking(x => x.BeEmpty("because we want to test the failure {0}", "message"))
                .ShouldThrow<AssertFailedException>()
                .WithMessage("Expected empty string because we want to test the failure message, but found \"ABC\".");
        }

        [TestMethod]
        public void When_checking_for_an_empty_string_and_it_is_null_it_should_throw()
        {
            //-----------------------------------------------------------------------------------------------------------
            // Arrange
            //-----------------------------------------------------------------------------------------------------------
            string nullString = null;

            //-----------------------------------------------------------------------------------------------------------
            // Act
            //-----------------------------------------------------------------------------------------------------------
            Action act = () => nullString.Should().BeEmpty("because strings should never be {0}", "null");

            //-----------------------------------------------------------------------------------------------------------
            // Assert
            //-----------------------------------------------------------------------------------------------------------
            act.ShouldThrow<AssertFailedException>().WithMessage(
                "Expected empty string because strings should never be null, but found <null>.");
        }

        [TestMethod]
        public void Should_succeed_when_asserting_non_empty_string_to_be_filled()
        {
            "ABC".Should().NotBeEmpty();
        }

        [TestMethod]
        [ExpectedException(typeof(AssertFailedException))]
        public void Should_fail_when_asserting_empty_string_to_be_filled()
        {
            "".Should().NotBeEmpty();
        }

        [TestMethod]
        public void Should_fail_with_descriptive_message_when_asserting_empty_string_to_be_filled()
        {
            var assertions = "".Should();
            assertions.Invoking(x => x.NotBeEmpty("because we want to test the failure {0}", "message"))
                .ShouldThrow<AssertFailedException>()
                .WithMessage("Did not expect empty string because we want to test the failure message.");
        }

        #endregion

        #region Length

        [TestMethod]
        public void Should_succeed_when_asserting_string_length_to_be_equal_to_the_same_value()
        {
            "ABC".Should().HaveLength(3);
        }

        [TestMethod]
        [ExpectedException(typeof(AssertFailedException))]
        public void Should_fail_when_asserting_string_length_to_be_equal_to_different_value()
        {
            "ABC".Should().HaveLength(1);
        }

        [TestMethod]
        public void Should_fail_with_descriptive_message_when_asserting_string_length_to_be_equal_to_different_value()
        {
            var assertions = "ABC".Should();
            assertions.Invoking(x => x.HaveLength(1, "because we want to test the failure {0}", "message"))
                .ShouldThrow<AssertFailedException>()
                .WithMessage(
                "Expected string with length <1> because we want to test the failure message, but found string \"ABC\" with length <3>.");
        }

        #endregion

        [TestMethod]
        public void When_chaining_multiple_assertions_it_should_assert_all_conditions()
        {
            "ABCDEFGHI".Should()
                .StartWith("AB").And
                .EndWith("HI").And
                .Contain("EF").And
                .HaveLength(9);
        }

        #region (Not) Null Or Empty

        [TestMethod]
        public void When_a_valid_string_is_expected_to_be_not_null_or_empty_it_should_not_throw()
        {
            //-----------------------------------------------------------------------------------------------------------
            // Arrange
            //-----------------------------------------------------------------------------------------------------------
            string str = "Hello World";

            //-----------------------------------------------------------------------------------------------------------
            // Act / Assert
            //-----------------------------------------------------------------------------------------------------------
            str.Should().NotBeNullOrEmpty();
        }

        [TestMethod]
        public void When_an_empty_string_is_not_expected_to_be_null_or_empty_it_should_throw()
        {
            //-----------------------------------------------------------------------------------------------------------
            // Arrange
            //-----------------------------------------------------------------------------------------------------------
            string str = "";

            //-----------------------------------------------------------------------------------------------------------
            // Act
            //-----------------------------------------------------------------------------------------------------------
            Action act = () => str.Should().NotBeNullOrEmpty("a valid string is expected for {0}", "str");

            //-----------------------------------------------------------------------------------------------------------
            // Act / Assert
            //-----------------------------------------------------------------------------------------------------------
            act.ShouldThrow<AssertFailedException>().WithMessage(
                "Expected string not to be <null> or empty because a valid string is expected for str, but found \"\".");
        }

        [TestMethod]
        public void When_a_null_string_is_not_expected_to_be_null_or_empty_it_should_throw()
        {
            //-----------------------------------------------------------------------------------------------------------
            // Arrange
            //-----------------------------------------------------------------------------------------------------------
            string str = null;

            //-----------------------------------------------------------------------------------------------------------
            // Act
            //-----------------------------------------------------------------------------------------------------------
            Action act = () => str.Should().NotBeNullOrEmpty("a valid string is expected for {0}", "str");

            //-----------------------------------------------------------------------------------------------------------
            // Act / Assert
            //-----------------------------------------------------------------------------------------------------------
            act.ShouldThrow<AssertFailedException>().WithMessage(
                "Expected string not to be <null> or empty because a valid string is expected for str, but found <null>.");
        }

        [TestMethod]
        public void When_a_null_string_is_expected_to_be_null_or_empty_it_should_not_throw()
        {
            //-----------------------------------------------------------------------------------------------------------
            // Arrange
            //-----------------------------------------------------------------------------------------------------------
            string str = null;

            //-----------------------------------------------------------------------------------------------------------
            // Act / Assert
            //-----------------------------------------------------------------------------------------------------------
            str.Should().BeNullOrEmpty();
        }

        [TestMethod]
        public void When_an_empty_string_is_expected_to_be_null_or_empty_it_should_not_throw()
        {
            //-----------------------------------------------------------------------------------------------------------
            // Arrange
            //-----------------------------------------------------------------------------------------------------------
            string str = "";

            //-----------------------------------------------------------------------------------------------------------
            // Act / Assert
            //-----------------------------------------------------------------------------------------------------------
            str.Should().BeNullOrEmpty();
        }

        [TestMethod]
        public void When_a_valid_string_is_expected_to_be_null_or_empty_it_should_throw()
        {
            //-----------------------------------------------------------------------------------------------------------
            // Arrange
            //-----------------------------------------------------------------------------------------------------------
            string str = "hello";

            //-----------------------------------------------------------------------------------------------------------
            // Act
            //-----------------------------------------------------------------------------------------------------------
            Action act = () => str.Should().BeNullOrEmpty("it was not initialized {0}", "yet");

            //-----------------------------------------------------------------------------------------------------------
            // Act / Assert
            //-----------------------------------------------------------------------------------------------------------
            act.ShouldThrow<AssertFailedException>().WithMessage(
                "Expected string to be <null> or empty because it was not initialized yet, but found \"hello\".");
        }

        #endregion

        #region (Not) Blank

        [TestMethod]
        public void Should_detect_blank_strings()
        {
            ((string)null).Should().BeBlank();
            "".Should().BeBlank();
            " ".Should().BeBlank();
            "\n\r".Should().BeBlank();

            "a".Should().NotBeBlank();
            " a ".Should().NotBeBlank();
        }

        [TestMethod]
        public void Should_throw_when_not_blank()
        {
            AssertEx.Throws<AssertFailedException>(() => "abc".Should().BeBlank())
                .WithMessage("Expected blank string, but found \"abc\".");

            AssertEx.Throws<AssertFailedException>(() => " def  ".Should().BeBlank())
                .WithMessage("Expected blank string, but found \" def  \".");
        }

        [TestMethod]
        public void Should_throw_when_blank()
        {
            AssertEx.Throws<AssertFailedException>(() => ((string)null).Should().NotBeBlank())
                .WithMessage("Expected non-blank string, but found <null>.");

            AssertEx.Throws<AssertFailedException>(() => "".Should().NotBeBlank())
                .WithMessage("Expected non-blank string, but found \"\".");

            AssertEx.Throws<AssertFailedException>(() => "   ".Should().NotBeBlank())
                .WithMessage("Expected non-blank string, but found \"   \".");
        }

        #endregion
    }
}