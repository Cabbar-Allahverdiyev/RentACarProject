CREATE TABLE [dbo].[Cars] (
    [CarId]          INT            NOT NULL,
    [BrandId]        INT            NOT NULL,
    [ModelId]        INT            NOT NULL,
    [ColorId]        INT            NOT NULL,
    [ModelYear]      INT            NOT NULL,
    [DailyPrice]     DECIMAL (18, 0) NOT NULL,
    [CarDescription] CHAR(250)           NOT NULL,
    PRIMARY KEY CLUSTERED ([CarId] ASC),
    FOREIGN KEY ([BrandId]) REFERENCES [dbo].[Brands] ([BrandId]),
    FOREIGN KEY ([ModelId]) REFERENCES [dbo].[Models] ([ModelId]),
    FOREIGN KEY ([ColorId]) REFERENCES [dbo].[Colors] ([ColorId])
);

