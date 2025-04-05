class PiModel:
    def __init__(self, story_points=0, fte=0):
        self.story_points = story_points
        self.fte = fte

    def story_points_to_fte(self):
        if self.story_points == 0:
            return 0
        return self.story_points / 20  # Assuming 20 story points per FTE

    def fte_to_story_points(self):
        if self.fte == 0:
            return 0
        return self.fte * 20  # Assuming 20 story points per FTE

    def __str__(self):
        return f"PiModel(Story Points: {self.story_points}, FTE: {self.fte})"