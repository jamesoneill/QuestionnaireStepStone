using JO.QuestionnaireStepStone.Interfaces.Data;
using JO.QuestionnaireStepStone.Interfaces.Core;
using JO.QuestionnaireStepStone.Core;
using Moq;
using JO.QuestionnaireStepStone.Data.Models;

namespace JO.QuestionnaireStepStone.UnitTests.Core
{
    public class QuestionnaireServiceTest
    {
        [Test]
        public async Task GetQuestionnaireTestAsync()
        {
            var questionnaireRepository = new Mock<IQuestionnaireRepository>();
            questionnaireRepository.Setup(m => m.GetQuestionnaireAsync()).ReturnsAsync(new Questionnaire()
            {
                QuestionnaireTitle = "Geography Questions",
                QuestionsText = new List<string>()
                {
                    "What is the capital of Cuba?",
                    "What is the capital of France?",
                    "What is the capital of Poland?",
                    "What is the capital of Germany?",
                }
            });

            IQuestionnaireService questionnaireService = new QuestionnaireService(questionnaireRepository.Object);

            var questionnaire = await questionnaireService.GetQuestionnaireAsync();

            var expectedOutcome = new Questionnaire()
            {
                QuestionnaireTitle = "Geography Questions",
                QuestionsText = new List<string>()
                {
                    "What is the capital of Cuba?",
                    "What is the capital of France?",
                    "What is the capital of Poland?",
                    "What is the capital of Germany?",
                }
            };

            Assert.IsNotNull(questionnaire);
            Assert.That(questionnaire.QuestionnaireTitle, Is.EqualTo(expectedOutcome.QuestionnaireTitle));
            Assert.That(questionnaire.QuestionsText[0], Is.EqualTo(expectedOutcome.QuestionsText[0]));
            Assert.That(questionnaire.QuestionsText[1], Is.EqualTo(expectedOutcome.QuestionsText[1]));
            Assert.That(questionnaire.QuestionsText[2], Is.EqualTo(expectedOutcome.QuestionsText[2]));
            Assert.That(questionnaire.QuestionsText[3], Is.EqualTo(expectedOutcome.QuestionsText[3]));

        }
    }
}